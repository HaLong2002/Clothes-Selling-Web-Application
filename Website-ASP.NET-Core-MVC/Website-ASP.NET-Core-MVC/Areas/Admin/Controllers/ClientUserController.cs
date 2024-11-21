using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Shared;
using System;
using Website_ASP.NET_Core_MVC.Areas.Admin.Models;
using Website_ASP.NET_Core_MVC.Data;
using Website_ASP.NET_Core_MVC.Models;
using X.PagedList.Extensions;

namespace Website_ASP.NET_Core_MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin,SuperAdmin")]
    public class ClientUserController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<User> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ClientUserController(ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IWebHostEnvironment webHostEnvironment)
		{
			_context = context;
			_userManager = userManager;
			_roleManager = roleManager;
			_webHostEnvironment = webHostEnvironment;
		}

		[HttpGet]
		public async Task<ActionResult> Index(string searchString, int page = 1, int pageSize = 5)
		{
			ViewBag.searchString = searchString;

			var taikhoans = await _userManager.GetUsersInRoleAsync("Customer");

			if (!String.IsNullOrEmpty(searchString))
			{
				taikhoans = taikhoans.Where(tk => tk.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
			}

            var taikhoansWithLockoutStatus = new List<ClientUserViewModel>();

            foreach (var user in taikhoans)
            {
                taikhoansWithLockoutStatus.Add(new ClientUserViewModel
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Address = user.Address,
                    Date = user.Date,
                    Gender = user.Gender,
                    LockoutStatus = await IsAccountLocked(user.Id)
                });
            }

            return View(taikhoansWithLockoutStatus.OrderBy(tk => tk.Id).ToPagedList(page, pageSize));
		}

        private async Task<bool> IsAccountLocked(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null) return false;

            return user.LockoutEnabled && user.LockoutEnd.HasValue && user.LockoutEnd > DateTimeOffset.UtcNow;
        }

        [HttpPost]
		public async Task<JsonResult> Index(string id)
		{
			var tk = await _userManager.FindByIdAsync(id);

			if (tk == null)
			{
				return Json(new { status = false, message = "Không tìm thấy người dùng!" });
			}

			var model = new ClientUserViewModel
			{
				Id = id,
				Email = tk.Email,
				FullName = tk.FullName,
				PhoneNumber = tk.PhoneNumber,
				Address = tk.Address,
				Date = tk.Date,
				Gender = tk.Gender,
				ExistingImage = tk.Image,
				LockoutStatus = await IsAccountLocked(tk.Id)
            };

			return Json(new { status = true, model });
		}

		[HttpPost]
		public async Task<JsonResult> Update(ClientUserViewModel model)
		{
			try
			{
				Console.WriteLine(model.Id);

				var tk = await _userManager.FindByIdAsync(model.Id);

				if (tk == null)
				{
					return Json(new { status = false, message = "Không tìm thấy người dùng!" });
				}

                if (model.ImageFile != null)
                {
                    var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images/CustomerAvatars");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    // Delete old image if exists
                    if (!string.IsNullOrEmpty(tk.Image))
                    {
                        var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, tk.Image.TrimStart('/'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // Save new image
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(fileStream);
                    }

                    tk.Image = "/Images/CustomerAvatars/" + uniqueFileName;
                }

                tk.Email = model.Email;
				tk.FullName = model.FullName;
				tk.Address = model.Address;
				tk.Date = model.Date;
				tk.Gender = model.Gender;

                var phoneNumber = await _userManager.GetPhoneNumberAsync(tk);
                if (model.PhoneNumber != phoneNumber)
                {
                    var setPhoneResult = await _userManager.SetPhoneNumberAsync(tk, model.PhoneNumber);
                    if (!setPhoneResult.Succeeded)
                    {
                        return Json(new { status = false, message = "Có lỗi gì đó khi thiết lập số điện thoại !" });
                    }
                }

                var result = await _userManager.UpdateAsync(tk);
                if (!result.Succeeded)
                {
                    return Json(new { status = false, message = "Có lỗi gì đó khi cập nhật thông tin người dùng !" });
                }                

                return Json(new { status = true, message = "Sửa thông tin thành công" });
			}
			catch (Exception)
			{
				return Json(new { status = false, message = "Có lỗi gì đó. Thử lại sau !" });
			}
		}

		[HttpPost]
		public async Task<JsonResult> Delete(string id)
		{
			try
			{
				var tk = await _userManager.FindByIdAsync(id);

				if (tk == null)
				{
					return Json(new { status = false, message = "Tài khoản không tồn tại!" });
				}

				var result = await _userManager.DeleteAsync(tk);

				if (result.Succeeded)
				{
					return Json(new { status = true, message = "Tài khoản đã được xóa thành công!" });
				}

				// Return errors if the deletion failed
				var errorMessages = string.Join("; ", result.Errors.Select(e => e.Description));
				return Json(new { status = false, message = $"Không thể xóa tài khoản: {errorMessages}" });
			}
			catch (Exception)
			{
				return Json(new { status = false, message = "Đã xảy ra lỗi! Thử lại sau." });
			}
		}
	}
}
