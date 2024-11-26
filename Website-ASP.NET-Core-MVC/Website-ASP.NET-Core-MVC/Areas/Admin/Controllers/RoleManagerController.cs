using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Website_ASP.NET_Core_MVC.Enums;
using Website_ASP.NET_Core_MVC.Models;

namespace Website_ASP.NET_Core_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = "SuperAdmin")]
	public class RoleManagerController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
		private readonly UserManager<User> _userManager;

		public RoleManagerController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
			_userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string roleName)
        {
            if (roleName != null)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
            }
            return RedirectToAction("Index");
        }

		[HttpPost]
		public async Task<IActionResult> Update(string RoleId, string RoleName)
		{
			if (string.IsNullOrWhiteSpace(RoleId) || string.IsNullOrWhiteSpace(RoleName))
			{
				ModelState.AddModelError("", "Thông tin không hợp lệ.");
				return RedirectToAction("Index");
			}

			var role = await _roleManager.FindByIdAsync(RoleId);
			if (role == null)
			{
				return NotFound("Loại tài khoản không tồn tại.");
			}

			role.Name = RoleName.Trim();
			var result = await _roleManager.UpdateAsync(role);

			if (result.Succeeded)
			{
				return RedirectToAction("Index");
			}

			foreach (var error in result.Errors)
			{
				ModelState.AddModelError("", error.Description);
			}

			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> DeleteRole(string roleId)
		{
			if (string.IsNullOrWhiteSpace(roleId))
			{
				return BadRequest("ID không hợp lệ.");
			}

			// Tìm role
			var role = await _roleManager.FindByIdAsync(roleId);
			if (role == null)
			{
				return NotFound("Loại tài khoản không tồn tại.");
			}

			// Kiểm tra xem role có được sử dụng hay không
			var usersInRole = await _userManager.GetUsersInRoleAsync(role.Name);
			if (usersInRole.Any())
			{
				TempData["ErrorMessage"] = $"Không thể xóa '{role.Name}' vì đang được sử dụng bởi {usersInRole.Count} người dùng.";
				return RedirectToAction("Index");
			}

			// Xóa role
			var result = await _roleManager.DeleteAsync(role);

			if (result.Succeeded)
			{
				TempData["SuccessMessage"] = "Xóa thành công.";
			}
			else
			{
				TempData["ErrorMessage"] = "Xóa thất bại.";
			}

			return RedirectToAction("Index");
		}

	}
}
