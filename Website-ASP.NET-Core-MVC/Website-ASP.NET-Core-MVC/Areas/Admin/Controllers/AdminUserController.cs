using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Website_ASP.NET_Core_MVC.Areas.Admin.Models;
using Website_ASP.NET_Core_MVC.Data;
using Website_ASP.NET_Core_MVC.Models;
using X.PagedList.Extensions;

namespace Website_ASP.NET_Core_MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "SuperAdmin")]

	public class AdminUserController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<User> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public AdminUserController(ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
		{
			_context = context;
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public async Task<ActionResult> Index(string searchString, int page = 1, int pageSize = 5)
		{
			var tk = await _userManager.GetUserAsync(User);

			ViewBag.searchString = searchString;

			var adminUsers = await _userManager.GetUsersInRoleAsync("Admin");
			var superAdminUsers = await _userManager.GetUsersInRoleAsync("SuperAdmin");

			var taikhoans = adminUsers
				.Union(superAdminUsers)
				.Distinct()
				.ToList();

			if (!String.IsNullOrEmpty(searchString))
			{
				taikhoans = taikhoans.Where(tk => tk.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
			}

			var taikhoansWithLockoutStatus = new List<AdminUserViewModel>();

			foreach (var user in taikhoans)
			{
				taikhoansWithLockoutStatus.Add(new AdminUserViewModel
				{
					Id = user.Id,
					FullName = user.FullName,
					Email = user.Email,
					EmailConfirmed = user.EmailConfirmed,
					LockoutStatus = await IsAccountLocked(user.Id) ? "Khóa" : "Không khóa",
					Roles = await GetUserRoles(user)
				});
			}

			var pagedTaikhoans = taikhoansWithLockoutStatus
				.OrderBy(tk => tk.Id)
				.ToPagedList(page, pageSize);
			
			return View(pagedTaikhoans);
		}

		private async Task<bool> IsAccountLocked(string userId)
		{
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null) return false;

			// Check if the account is locked
			return user.LockoutEnabled && user.LockoutEnd.HasValue && user.LockoutEnd > DateTimeOffset.UtcNow;
		}

		private async Task<List<string>> GetUserRoles(User user)
		{
			return new List<string>(await _userManager.GetRolesAsync(user));
		}

		[HttpPost]
		public async Task<JsonResult> Create([FromBody] CreateAdminAccount model)
		{
			if (model.Roles == null || model.Roles.Count == 0)
			{
				return Json(new
				{
					status = false,
					message = "Vui lòng chọn ít nhất một loại tài khoản"
				});
			}

			var existingUser = await _userManager.FindByEmailAsync(model.Email);
			if (existingUser != null)
			{
				return Json(new
				{
					status = false,
					message = "Email đã được sử dụng. Vui lòng chọn email khác."
				});
			}

			var admin = new User
			{
				UserName = model.Email,
				Email = model.Email,
				FullName = model.FullName,
				EmailConfirmed = true
			};

			var result = await _userManager.CreateAsync(admin, model.Password);

			if (result.Succeeded)
			{
				foreach (var role in model.Roles)
				{
					await _userManager.AddToRoleAsync(admin, role);
				}

				return Json(new { status = true, message = "Thêm tài khoản thành công!" });
			}

			var addErrors = string.Join("; ", result.Errors.Select(e => e.Description));
			return Json(new { status = false, message = $"{addErrors}" });
		}

		[HttpPost]
		public async Task<JsonResult> Index(string id)
		{
			var user = await _userManager.FindByIdAsync(id);

			if (user == null)
			{
				return Json(new { success = false, message = "Không tìm thấy người dùng" });
			}

			var allRoles = await _roleManager.Roles
							.Where(r => r.Name != "Customer")
							.Select(r => r.Name)
							.ToListAsync();

			return Json(new
			{
				success = true,
				user = new
				{
					Id = user.Id,
					FullName = user.FullName,
					Email = user.Email,
					EmailConfirmed = user.EmailConfirmed,
					LockoutStatus = await IsAccountLocked(user.Id) ? "Khóa" : "Không khóa",
					Roles = await _userManager.GetRolesAsync(user)
				},
				allRoles // Send all available roles
			});
		}

		[HttpPost]
		public async Task<JsonResult> LoadRoles()
		{
			var allRoles = await _roleManager.Roles
							.Where(r => r.Name != "Customer") // Exclude "Customer role"
							.Select(r => r.Name)
							.ToListAsync();

			return Json(new
			{
				success = true,
				allRoles // Send all available roles
			});
		}

		[HttpPost]
		public async Task<JsonResult> Update([FromBody] AdminUserViewModel tk)
		{
			var loginUser = await _userManager.GetUserAsync(User); // Get the currently logged-in user

			if (tk == null)
			{
				return Json(new { status = false, message = "User null!" });
			}

			try
			{
				// Find the user to be updated by ID
				var updateUser = await _userManager.FindByIdAsync(tk.Id);

				if (updateUser == null)
				{
					return Json(new { status = false, message = "Tài khoản không tồn tại!" });
				}

				if (updateUser.Id == loginUser.Id)
				{
					return Json(new { status = false, message = "Bạn không thể chỉnh sửa tài khoản của chính mình!" });
				}

				// Update user properties
				updateUser.EmailConfirmed = tk.EmailConfirmed;

				if (tk.LockoutStatus == "Khóa")
				{
					await _userManager.SetLockoutEndDateAsync(updateUser, DateTime.UtcNow.AddYears(100)); // Locked indefinitely
				}
				else
				{
					await _userManager.SetLockoutEndDateAsync(updateUser, null); // Unlock
				}

				// Update user roles (if roles are provided in the request)
				if (tk.Roles != null && tk.Roles.Any())
				{
					// Get current roles
					var currentRoles = await _userManager.GetRolesAsync(updateUser);

					// Determine roles to add and remove
					var rolesToAdd = tk.Roles.Except(currentRoles);
					var rolesToRemove = currentRoles.Except(tk.Roles);

					// Update roles
					if (rolesToRemove.Any())
					{
						var removeResult = await _userManager.RemoveFromRolesAsync(updateUser, rolesToRemove);
						if (!removeResult.Succeeded)
						{
							var removeErrors = string.Join("; ", removeResult.Errors.Select(e => e.Description));
							return Json(new { status = false, message = $"Lỗi khi xóa vai trò: {removeErrors}" });
						}
					}

					if (rolesToAdd.Any())
					{
						var addResult = await _userManager.AddToRolesAsync(updateUser, rolesToAdd);
						if (!addResult.Succeeded)
						{
							var addErrors = string.Join("; ", addResult.Errors.Select(e => e.Description));
							return Json(new { status = false, message = $"Lỗi khi thêm vai trò: {addErrors}" });
						}
					}
				}

				// Update the user with UserManager
				var result = await _userManager.UpdateAsync(updateUser);

				if (result.Succeeded)
				{
					return Json(new { status = true, message = "Sửa thông tin thành công!" });
				}

				// Return errors if the update failed
				var updateErrors = string.Join("; ", result.Errors.Select(e => e.Description));
				return Json(new { status = false, message = $"Có lỗi xảy ra: {updateErrors}" });
			}
			catch (Exception)
			{
				return Json(new { status = false, message = "Có lỗi gì đó. Thử lại sau!" });
			}
		}

		[HttpPost]
		public async Task<JsonResult> Delete(string id)
		{
			var loginUser = await _userManager.GetUserAsync(User); // Get the currently logged-in user

			try
			{
				// Find the user to be deleted by ID
				var userToDelete = await _userManager.FindByIdAsync(id);

				if (userToDelete == null)
				{
					return Json(new { status = false, message = "Tài khoản không tồn tại!" });
				}

				// Prevent deleting the currently logged-in user's account
				if (userToDelete.UserName.Equals(loginUser.UserName, StringComparison.OrdinalIgnoreCase))
				{
					return Json(new { status = false, message = "Bạn không thể xóa tài khoản của chính mình!" });
				}

				// Use UserManager to delete the user
				var result = await _userManager.DeleteAsync(userToDelete);

				if (result.Succeeded)
				{
					return Json(new { status = true, message = "Tài khoản đã được xóa thành công!" });
				}

				// Return errors if the deletion failed
				var errorMessages = string.Join("; ", result.Errors.Select(e => e.Description));
				return Json(new { status = false, message = $"Không thể xóa tài khoản: {errorMessages}" });
			}
			catch (Exception ex)
			{
				// Handle any unexpected exceptions
				return Json(new { status = false, message = "Đã xảy ra lỗi! Thử lại sau." });
			}
		}

	}
}
