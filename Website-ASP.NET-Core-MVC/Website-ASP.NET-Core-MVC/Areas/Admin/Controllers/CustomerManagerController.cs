using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Website_ASP.NET_Core_MVC.Areas.Admin.Models;
using Website_ASP.NET_Core_MVC.Models;

namespace Website_ASP.NET_Core_MVC.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
    public class CustomerManagerController : Controller
    {
		private readonly UserManager<User> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public CustomerManagerController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			var customers = await _userManager.GetUsersInRoleAsync("Customer");
			var listUserViewModel = new List<UserViewModel>();

			foreach (User customer in customers)
			{
				var thisViewModel = new UserViewModel();
				thisViewModel.UserId = customer.Id;
				thisViewModel.Email = customer.Email;
				thisViewModel.FullName = customer.FullName;
				thisViewModel.Gender = customer.Gender;
				thisViewModel.Date = customer.Date;
				thisViewModel.Address = customer.Address;
				thisViewModel.Roles = await GetUserRoles(customer);
				thisViewModel.Image = customer.Image;
				thisViewModel.Phone = customer.PhoneNumber;

				listUserViewModel.Add(thisViewModel);
			}

			return View(listUserViewModel);
		}

		private async Task<List<string>> GetUserRoles(User user)
		{
			return new List<string>(await _userManager.GetRolesAsync(user));
		}
	}
}
