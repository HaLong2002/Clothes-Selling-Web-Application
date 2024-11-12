using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Website_ASP.NET_Core_MVC.Areas.Admin.Models;
using Website_ASP.NET_Core_MVC.Models;

namespace Website_ASP.NET_Core_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserRolesController : Controller
    {
		private readonly UserManager<User> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public UserRolesController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
            //var customers = await _userManager.GetUsersInRoleAsync("Customer");
            var users = await _userManager.Users.ToListAsync();

            var listUserViewModel = new List<UserRolesViewModel>();

			foreach (User user in users)
			{
				var thisViewModel = new UserRolesViewModel();
				thisViewModel.UserId = user.Id;
				thisViewModel.Email = user.Email;
				thisViewModel.Username = user.UserName;
				thisViewModel.FullName = user.FullName;
				//thisViewModel.Gender = user.Gender;
				//thisViewModel.Date = user.Date;
				//thisViewModel.Address = user.Address;
				thisViewModel.Roles = await GetUserRoles(user);
				//thisViewModel.Image = user.Image;
				//thisViewModel.Phone = user.PhoneNumber;

				listUserViewModel.Add(thisViewModel);
			}

			return View(listUserViewModel);
		}

		private async Task<List<string>> GetUserRoles(User user)
		{
			return new List<string>(await _userManager.GetRolesAsync(user));
		}

        public async Task<IActionResult> Manage(string userId)
        {
            ViewBag.userId = userId;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"Người dùng có ID = {userId} không thể tìm thấy";
                return View("NotFound");
            }

            ViewBag.UserName = user.UserName;
            var model = new List<ManageUserRolesViewModel>();

            foreach (var role in _roleManager.Roles)
            {
                var userRolesViewModel = new ManageUserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.Selected = true;
                }
                else
                {
                    userRolesViewModel.Selected = false;
                }
                model.Add(userRolesViewModel);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(List<ManageUserRolesViewModel> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View();
            }

            // Lấy các vai trò của user sau đó xóa các vai trò đó
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Không thể xóa vai trò hiện tại của người dùng");
                return View(model);
            }

            result = await _userManager.AddToRolesAsync(user, model.Where(x => x.Selected).Select(y => y.RoleName));
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Không thể thêm vai trò đã chọn vào người dùng");
                return View(model);
            }

            return RedirectToAction("Index");
        }
    }
}
