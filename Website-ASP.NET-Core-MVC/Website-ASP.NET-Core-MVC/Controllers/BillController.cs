using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Website_ASP.NET_Core_MVC.Data;
using Website_ASP.NET_Core_MVC.Models;

namespace Website_ASP.NET_Core_MVC.Controllers
{
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
        public async Task<ActionResult> ListBills()
        {
            List<HoaDon> list = new List<HoaDon>();
            var tk = await _userManager.GetUserAsync(User);

            if (tk == null || tk.Id == null)
            {
                return View("NotFound");
            }

            list = _context.HoaDons
                            .Where(p => p.MaTK == tk.Id)  // Ensure NgayDat is not null
                            .OrderByDescending(x => x.NgayDat)
                            .ToList();

            return View(list);
        }


        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var tk = await _userManager.GetUserAsync(User);
            if (tk == null)
            {
                return View("NotFound");
            }

            if (_context.HoaDons.FirstOrDefault(x => x.MaTK == tk.Id) == null)
            {
                return View("NotFound");
            }

            HoaDon hd = _context.HoaDons
                .Include(x => x.ChiTietHoaDons)
                .ThenInclude(x => x.SanPhamChiTiet)
                .ThenInclude(x => x.SanPham)
                .Include(x => x.ChiTietHoaDons)
                .ThenInclude(x => x.SanPhamChiTiet)
                .ThenInclude(x => x.KichCo)
                .Where(x => x.MaHD == id)
                .FirstOrDefault();

            return View(hd);
        }

        [HttpPost]
        public JsonResult CreateBill([FromBody] HoaDon hd)
        {
            try
            {
                hd.NgayDat = DateTime.Now;
                hd.NgaySua = DateTime.Now;
                hd.NguoiSua = "";
                hd.TrangThai = 1;
                _context.HoaDons.Add(hd);
                _context.SaveChanges();
                var cartJson = HttpContext.Session.GetString(Session.ConstainCart.CART);

                List<ChiTietHoaDon> list = string.IsNullOrEmpty(cartJson)
                                ? new List<ChiTietHoaDon>()
                                : JsonConvert.DeserializeObject<List<ChiTietHoaDon>>(cartJson);

                foreach (ChiTietHoaDon item in list)
                {
                    item.MaHD = hd.MaHD;
                    _context.ChiTietHoaDons.Add(item);
                    _context.SaveChanges();
                }
                HttpContext.Session.Remove(Session.ConstainCart.CART);
                return Json(new { status = true, billid = hd.MaHD });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = "Có lỗi gì đó! Thử lại sau" + ex.Message });
            }

        }

        [HttpPost]
        public async Task<JsonResult> ChangeStatus(int mahd, int stt)
        {
            try
            {
                var tk = await _userManager.GetUserAsync(User);
                HoaDon hd = _context.HoaDons.Where(x => x.MaHD == mahd).FirstOrDefault();
                if (hd.TrangThai != 1)
                {
                    return Json(new { status = false });
                }
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
