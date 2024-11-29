using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Website_ASP.NET_Core_MVC.Data;
using Website_ASP.NET_Core_MVC.Models;
using X.PagedList.Extensions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Website_ASP.NET_Core_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin,Sale")]
    public class BillController : Controller
	{
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public BillController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult Index(DateTime? searchString, int? status, int page = 1, int pageSize = 10)
        {
            List<HoaDon> hoaDons = _context.HoaDons.Include("User").Select(p => p).ToList();
            if (status != null)
            {
                hoaDons = hoaDons.Where(x => x.TrangThai == status).ToList();
                ViewBag.Status = status;
            }
            if (searchString != null)
            {
                ViewBag.searchString = searchString.Value.ToString("yyyy-MM-dd");
                string search = searchString.Value.ToString("dd/MM/yyyy");
                hoaDons = hoaDons.Where(hd => hd.NgayDat.ToString().Contains(search)).ToList();
            }
            return View(hoaDons.OrderBy(hd => hd.NgayDat).ToPagedList(page, pageSize));
        }

        [HttpPost]
        public JsonResult Index(int id)
        {
            // Fetch HoaDon with User data
            var hd = _context.HoaDons
                .Include(h => h.User)
                .Where(h => h.MaHD == id)
                .Select(h => new
                {
                    h.MaHD,
                    h.HoTenNguoiNhan,
                    h.TrangThai,
                    h.NgayDat,
                    h.SoDienThoaiNhan,
                    h.DiaChiNhan,
                    h.NguoiSua,
                    h.NgaySua,
                    h.GhiChu,
                    User = new { h.User.FullName }
                })
                .FirstOrDefault();

            // Fetch ChiTietHoaDons with related SanPhamChiTiet and KichCo data
            var chiTietHoaDons = _context.ChiTietHoaDons
                .Include(ct => ct.SanPhamChiTiet)
                .ThenInclude(spct => spct.KichCo)
                .Where(ct => ct.MaHD == id)
                .Select(ct => new
                {
                    ct.GiaMua,
                    ct.SoLuongMua,
                    SanPhamChiTiet = new
                    {
                        ct.SanPhamChiTiet.MaSP,
                        ct.SanPhamChiTiet.KichCo.TenKichCo
                    }
                })
                .ToList();

            // Fetch related SanPhams in a single query
            var sanPhamIds = chiTietHoaDons.Select(ct => ct.SanPhamChiTiet.MaSP).Distinct();
            var sanPhams = _context.SanPhams
                .Where(sp => sanPhamIds.Contains(sp.MaSP))
                .Select(sp => new
                {
                    sp.MaSP,
                    sp.TenSP,
                    sp.HinhAnh
                })
                .ToList();

            // Return the data as JSON
            return Json(new { hoadon = hd, cthd = chiTietHoaDons, sp = sanPhams });
        }



        [HttpPost]
        public async Task<JsonResult> ChangeStatus(int mahd, int stt)
        {
            try
            {
                //TaiKhoanQuanTri tk = (TaiKhoanQuanTri)Session[Nhom9.Session.ConstaintUser.ADMIN_SESSION];
                var tk = await _userManager.GetUserAsync(User);

                HoaDon hd = _context.HoaDons.Where(x => x.MaHD == mahd).FirstOrDefault();
                hd.TrangThai = stt;
                hd.NguoiSua = tk.FullName;
                hd.NgaySua = DateTime.Now;
                _context.SaveChanges();
                return Json(new { status = true, message = "Thêm thành công"});
            }
            catch (Exception ex)
            {
                return Json(new { status = false, error =  ex.Message});
                }
        }
    }
}
