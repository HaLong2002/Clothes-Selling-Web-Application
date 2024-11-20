﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

            var taikhoansWithLockoutStatus = new List<UserViewModel>();

            foreach (var user in taikhoans)
            {
                taikhoansWithLockoutStatus.Add(new UserViewModel
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
        public async Task<JsonResult> Create([FromBody] CreateAccount tk)
        {
            if (ModelState.IsValid)
            {
                var admin = new User
                {
                    UserName = tk.Email,
                    Email = tk.Email,
                    FullName = tk.FullName,
                    EmailConfirmed = true,
                    //PhoneNumberConfirmed = true
                };

                if (_userManager.Users.All(u => u.Id != admin.Id))
                {
                    var user = await _userManager.FindByEmailAsync(admin.Email);
                    if (user == null)
                    {
                        await _userManager.CreateAsync(admin, tk.Password);
                        await _userManager.AddToRoleAsync(admin, Enums.Roles.Admin.ToString());
                        return Json(new { status = true, message = "Thêm thành công!" });
                    }
                    else
                    {
                        return Json(new { status = false, message = "Email đã tồn tại!" });
                    }
                }
            }
            return Json(new { status = false, message = "Thêm không thành công!" });
        }

        [HttpPost]
        public async Task<JsonResult> Index(string id)
        {
            // Retrieve the user by ID using UserManager
            var user = await _userManager.FindByIdAsync(id);

            // Check if the user exists
            if (user == null)
            {
                return Json(new { success = false, message = "Không tìm thấy người dùng" });
            }

            var allRoles = await _roleManager.Roles
                .Where(r => r.Name != "Customer") // Exclude "Customer role"
                .Select(r => r.Name)
                .ToListAsync();

            var userRoles = await _userManager.GetRolesAsync(user);

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
                    Roles = userRoles
                },
                allRoles // Send all available roles
            });
        }

        //[HttpPost]
        //public JsonResult Update(TaiKhoanQuanTri tk)
        //{
        //    TaiKhoanQuanTri login = (TaiKhoanQuanTri)Session[Nhom9.Session.ConstaintUser.ADMIN_SESSION];
        //    try
        //    {
        //        TaiKhoanQuanTri update = _context.TaiKhoanQuanTris.Where(a => a.ID.Equals(tk.ID)).FirstOrDefault();
        //        if (update.TenDangNhap.Equals(login.TenDangNhap))
        //        {
        //            return Json(new { status = false, message = "Bạn không thể sửa tài khoản này !" });
        //        }
        //        update.LoaiTaiKhoan = tk.LoaiTaiKhoan;
        //        update.TrangThai = tk.TrangThai;
        //        _context.Entry(update).State = EntityState.Modified;
        //        _context.SaveChanges();
        //        return Json(new { status = true, message = "Sửa thông tin thành công" });
        //    }
        //    catch (Exception)
        //    {
        //        return Json(new { status = false, message = "Có lỗi gì đó. Thử lại sau !" });
        //    }
        //}

        [HttpPost]
        public async Task<JsonResult> Update([FromBody] UserViewModel tk)
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

        //[HttpPost]
        //public JsonResult Delete(int id)
        //{
        //    TaiKhoanQuanTri login = (TaiKhoanQuanTri)Session[Nhom9.Session.ConstaintUser.ADMIN_SESSION];
        //    try
        //    {
        //        TaiKhoanQuanTri tk = _context.TaiKhoanQuanTris.Where(a => a.ID.Equals(id)).FirstOrDefault();
        //        if (tk.TenDangNhap.Equals(login.TenDangNhap))
        //        {
        //            return Json(new { status = false, message = "Bạn không thể xóa tài khoản này !" });
        //        }
        //        _context.TaiKhoanQuanTris.Remove(tk);
        //        _context.SaveChanges();
        //        return Json(new { status = true });
        //    }
        //    catch (Exception)
        //    {
        //        return Json(new { status = false });
        //    }
        //}

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
