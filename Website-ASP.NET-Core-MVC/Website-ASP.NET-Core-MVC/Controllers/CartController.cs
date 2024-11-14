using Microsoft.AspNetCore.Authorization;
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
        private readonly ILogger<CartController> _logger;
        private readonly ApplicationDbContext _context;
		private readonly UserManager<User> _userManager;

		public CartController(ApplicationDbContext context, UserManager<User> userManager, ILogger<CartController> logger)
		{
			_context = context;
			_userManager = userManager;
			_logger = logger;
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
		public JsonResult AddToCart([FromBody] ChiTietHoaDon chiTiet)
		{

            var cartJson = HttpContext.Session.GetString(Session.ConstainCart.CART);

			var sanPhamChiTiet = _context.SanPhamChiTiets.Where(x => x.IDCTSP == chiTiet.IDCTSP).FirstOrDefault();

			if (sanPhamChiTiet == null)
			{
				// Handle the case when no matching SanPhamChiTiet is found
				return Json(new { status = false, message = "Product detail not found." });
			}

			if (chiTiet.SoLuongMua > sanPhamChiTiet.SoLuong)
			{
				return Json(new { status = false, message = "Insufficient stock." });
			}

			// Proceed with other logic if there is enough stock

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

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> CheckOut()
		{
			var user = await _userManager.GetUserAsync(User);
			
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
