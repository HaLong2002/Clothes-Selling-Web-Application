using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Website_ASP.NET_Core_MVC.Models;

namespace Website_ASP.NET_Core_MVC.Components
{
	public class CartCountViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var cart = HttpContext.Session.GetString("CART");

			List<ChiTietHoaDon> list = new List<ChiTietHoaDon>();

			if (!string.IsNullOrEmpty(cart))
			{
				list = JsonConvert.DeserializeObject<List<ChiTietHoaDon>>(cart);
			}

			return View(list);
		}
	}
}
