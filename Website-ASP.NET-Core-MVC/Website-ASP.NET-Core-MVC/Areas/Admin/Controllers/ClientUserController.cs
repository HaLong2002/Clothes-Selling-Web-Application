using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Website_ASP.NET_Core_MVC.Areas.Admin.Controllers
{

    [Authorize(Roles = "Admin,SuperAdmin")]
    public class ClientUserController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
