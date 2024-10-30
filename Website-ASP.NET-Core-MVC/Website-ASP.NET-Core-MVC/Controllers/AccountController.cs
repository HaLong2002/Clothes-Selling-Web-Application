using Microsoft.AspNetCore.Mvc;

namespace Website_ASP.NET_Core_MVC.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Login()
		{
			return View();
		}
	}
}
