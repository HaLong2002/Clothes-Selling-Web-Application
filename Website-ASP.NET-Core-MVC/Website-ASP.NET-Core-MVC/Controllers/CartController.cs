using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Website_ASP.NET_Core_MVC.Data;
using Website_ASP.NET_Core_MVC.Models;

namespace Website_ASP.NET_Core_MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public CartController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult Orders()
        {
            var cartJson = HttpContext.Session.GetString(Session.ConstainCart.CART);

            List<SanPhamChiTiet> list = new List<SanPhamChiTiet>();
            if (HttpContext.Session.GetString(Session.ConstainCart.CART) != null)
            {
                List<ChiTietHoaDon> ses = string.IsNullOrEmpty(cartJson)
                                ? new List<ChiTietHoaDon>()
                                : JsonConvert.DeserializeObject<List<ChiTietHoaDon>>(cartJson); foreach (ChiTietHoaDon item in ses)
                {
                    list.Add(_context.SanPhamChiTiets.Include("SanPham").Include("KichCo").Where(s => s.IDCTSP == item.IDCTSP).FirstOrDefault());
                }
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].ChiTietHoaDons.Add(ses[i]);
                }
            }
            return View(list);
        }

        [HttpPost]
        public JsonResult AddToCart(ChiTietHoaDon chiTiet)
        {
            var cartJson = HttpContext.Session.GetString(Session.ConstainCart.CART);

            if (chiTiet.SoLuongMua > _context.SanPhamChiTiets.Where(x => x.IDCTSP == chiTiet.IDCTSP).FirstOrDefault().SoLuong)
            {
                return Json(new { status = false });
            }
            bool isExists = false;
            List<ChiTietHoaDon> list = new List<ChiTietHoaDon>();
            if (HttpContext.Session.GetString(Session.ConstainCart.CART) != null)
            {
                list = string.IsNullOrEmpty(cartJson)
                            ? new List<ChiTietHoaDon>()
                            : JsonConvert.DeserializeObject<List<ChiTietHoaDon>>(cartJson);

                foreach (ChiTietHoaDon item in list)
                {
                    if (item.IDCTSP == chiTiet.IDCTSP)
                    {
                        item.SoLuongMua += chiTiet.SoLuongMua;
                        isExists = true;
                    }
                }
                if (!isExists)
                {
                    list.Add(chiTiet);
                }
            }
            else
            {
                list = new List<ChiTietHoaDon>();
                list.Add(chiTiet);
            }
            list.RemoveAll((x) => x.SoLuongMua <= 0);
            foreach (ChiTietHoaDon item in list)
            {
                item.GiaMua = _context.SanPhamChiTiets.Include("SanPham").Where(s => s.IDCTSP == item.IDCTSP).FirstOrDefault().SanPham.Gia;
            }
            HttpContext.Session.SetString(Session.ConstainCart.CART, JsonConvert.SerializeObject(list));
            return Json(new { status = true, cart = list });
        }

        [HttpPost]
        public JsonResult DeleteFromCart(int idctsp)
        {
            var cartJson = HttpContext.Session.GetString(Session.ConstainCart.CART);

            List<ChiTietHoaDon> list = string.IsNullOrEmpty(cartJson)
                            ? new List<ChiTietHoaDon>()
                            : JsonConvert.DeserializeObject<List<ChiTietHoaDon>>(cartJson);
            
            list.RemoveAll((x) => x.IDCTSP == idctsp);

            HttpContext.Session.SetString(Session.ConstainCart.CART, JsonConvert.SerializeObject(list));
            return Json(list);
        }

        //[HttpGet]
        //public async Task<IActionResult> CheckOut()
        //{
        //    //TaiKhoanNguoiDung tk = (TaiKhoanNguoiDung)Session[Nhom9.Session.ConstaintUser.USER_SESSION];
        //    var user = await _userManager.GetUserAsync(User);

        //    if (user == null)
        //    {
        //        return RedirectToAction("Login", "Home");
        //    }
        //    List<SanPhamChiTiet> list = new List<SanPhamChiTiet>();
        //    List<ChiTietHoaDon> ses = (List<ChiTietHoaDon>)Session[Session.ConstainCart.CART];
        //    ViewBag.TaiKhoan = user;
        //    foreach (ChiTietHoaDon item in ses)
        //    {
        //        list.Add(_context.SanPhamChiTiets.Include("SanPham").Include("KichCo").Where(s => s.IDCTSP == item.IDCTSP).FirstOrDefault());
        //    }
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        list[i].ChiTietHoaDons.Add(ses[i]);
        //    }
        //    return View(list);
        //}

        [HttpGet]
        public async Task<IActionResult> CheckOut()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }

            // Retrieve the session data
            var cartJson = HttpContext.Session.GetString(Session.ConstainCart.CART);
            List<ChiTietHoaDon> ses = string.IsNullOrEmpty(cartJson)
                ? new List<ChiTietHoaDon>()
                : JsonConvert.DeserializeObject<List<ChiTietHoaDon>>(cartJson);

            List<SanPhamChiTiet> list = new List<SanPhamChiTiet>();
            ViewBag.TaiKhoan = user;

            foreach (ChiTietHoaDon item in ses)
            {
                var productDetail = _context.SanPhamChiTiets
                                            .Include(s => s.SanPham)
                                            .Include(s => s.KichCo)
                                            .FirstOrDefault(s => s.IDCTSP == item.IDCTSP);
                if (productDetail != null)
                {
                    list.Add(productDetail);
                }
            }

            // Attach order details to each product
            for (int i = 0; i < list.Count; i++)
            {
                list[i].ChiTietHoaDons.Add(ses[i]);
            }

            return View(list);
        }

    }
}
