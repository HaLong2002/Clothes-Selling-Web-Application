using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Website_ASP.NET_Core_MVC.Data;
using Website_ASP.NET_Core_MVC.Models;
using X.PagedList.Extensions;

namespace Website_ASP.NET_Core_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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
            HoaDon hd = _context.HoaDons.Include("User")
                .Where(x => x.MaHD == id).FirstOrDefault();
            IEnumerable<ChiTietHoaDon> chiTietHoaDons = _context.ChiTietHoaDons.Include("SanPhamChiTiet")
                .Include("SanPhamChiTiet.KichCo")
                .Where(x => x.MaHD == id);
            List<SanPham> list = new List<SanPham>();
            foreach (ChiTietHoaDon item in chiTietHoaDons)
            {
                list.Add(_context.SanPhams.Where(x => x.MaSP == item.SanPhamChiTiet.MaSP).FirstOrDefault());
            }
            return Json(new { hoadon = hd, cthd = chiTietHoaDons, sp = list });
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
                return Json(new { status = true });
            }
            catch (Exception)
            {
                return Json(new { status = false });
            }
        }
    }
}
