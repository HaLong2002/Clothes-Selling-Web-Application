using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Website_ASP.NET_Core_MVC.Models;

namespace Website_ASP.NET_Core_MVC.Areas.Admin.Controllers
{
    public class UserManagerController : Controller
    {
        private readonly UserManager<User> _userManager;

        public UserManagerController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }
    }
}
