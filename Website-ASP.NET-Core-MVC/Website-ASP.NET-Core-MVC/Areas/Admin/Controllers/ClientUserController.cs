using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Shared;
using System;
using System.Text.Encodings.Web;
using System.Text;
using Website_ASP.NET_Core_MVC.Areas.Admin.Models;
using Website_ASP.NET_Core_MVC.Data;
using Website_ASP.NET_Core_MVC.Models;
using X.PagedList.Extensions;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Website_ASP.NET_Core_MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin,SuperAdmin,Sale")]
	public class ClientUserController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<User> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly IEmailSender _emailSender;

		public ClientUserController(ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IWebHostEnvironment webHostEnvironment, IEmailSender emailSender)
		{
			_context = context;
			_userManager = userManager;
			_roleManager = roleManager;
			_webHostEnvironment = webHostEnvironment;
			_emailSender = emailSender;
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
					LockoutStatus = await IsAccountLocked(user.Id),
					EmailConfirmed = user.EmailConfirmed,
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
		public async Task<JsonResult> Create([FromBody] CreateAccountClient model)
		{
			try
			{
				if (model == null)
				{
					return Json(new { status = false, message = "Dữ liệu không hợp lệ." });
				}

				if (!ModelState.IsValid)
				{
					var errorsModel = ModelState.Values
						.SelectMany(v => v.Errors)
						.Select(e => e.ErrorMessage);
					return Json(new { status = false, message = string.Join(", ", errorsModel) });
				}

				if (string.IsNullOrEmpty(model.Email))
				{
					return Json(new { status = false, message = "Email không được để trống." });
				}

				var existingUser = await _userManager.FindByEmailAsync(model.Email.Trim());
				if (existingUser != null)
				{
					return Json(new
					{
						status = false,
						message = "Email đã được sử dụng. Vui lòng chọn email khác."
					});
				}

				var client = new User
				{
					UserName = model.Email.Trim(),
					Email = model.Email.Trim(),
					FullName = model.FullName?.Trim(),
					PhoneNumber = model.PhoneNumber?.Trim(),
					Address = model.Address?.Trim(),
					Date = model.Date,
					Gender = model.Gender?.Trim(),
					Image = null
				};

				var result = await _userManager.CreateAsync(client, model.Password);
				if (result.Succeeded)
				{
					await _userManager.AddToRoleAsync(client, Enums.Roles.Customer.ToString());

					// Generate email confirmation token and URL
					var userId = await _userManager.GetUserIdAsync(client);
					var code = await _userManager.GenerateEmailConfirmationTokenAsync(client);
					code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

					var callbackUrl = Url.Page(
						"/Account/ConfirmEmail",
						pageHandler: null,
						values: new { area = "Identity", userId = userId, code = code },
						protocol: Request.Scheme);

					await _emailSender.SendEmailAsync(
						client.Email,
						"Xác nhận Email của bạn",
						$"Vui lòng xác nhận tài khoản tại đây <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

					return Json(new
					{
						status = true,
						message = "Email xác nhận đã được gửi. Hãy kiểm tra hộp thư của bạn !"
					});
				}

				var errors = string.Join("; ", result.Errors.Select(e => e.Description));
				return Json(new { status = false, message = errors });
			}
			catch (Exception ex)
			{
				// Log the exception here
				return Json(new
				{
					status = false,
					message = "Đã xảy ra lỗi trong quá trình xử lý. Vui lòng thử lại sau."
				});
			}
		}

		[HttpPost]
		public async Task<JsonResult> Index(string id)
		{
			Console.WriteLine("Index is called");
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
				var tk = await _userManager.FindByIdAsync(model.Id);

				if (tk == null)
				{
					return Json(new { status = false, message = "Không tìm thấy người dùng!" });
				}

				if (model.Email != tk.Email)
				{
					return Json(new { status = false, message = "Vui lòng nhấn 'Đổi email' để thực hiện thay đổi email !" });
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

				if (model.LockoutStatus)
				{
					await _userManager.SetLockoutEndDateAsync(tk, DateTime.UtcNow.AddYears(100)); // Locked indefinitely
				}
				else
				{
					await _userManager.SetLockoutEndDateAsync(tk, null);   // Unlock
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

		[HttpGet]
		public async Task<JsonResult> ChangeEmail(string id, string email)
		{
			if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(email))
			{
				return Json(new { status = false, message = "Đường link không hợp lệ !" });
			}

			var client = await _userManager.FindByIdAsync(id);
			if (client == null)
			{
				return Json(new { status = false, message = "Không tìm thấy người dùng !" });
			}

			if (email == client.Email)
			{
				return Json(new { status = false, message = "Vui lòng nhập email khác để thay đổi!" });
			}

			var emailExists = await _userManager.FindByEmailAsync(email);
			if (emailExists != null && emailExists.Id != id)
			{
				return Json(new { status = false, message = "Email đã tồn tại. Vui lòng nhập email khác!" });
			}

			var code = await _userManager.GenerateChangeEmailTokenAsync(client, email);
			code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
			var callbackUrl = Url.Page(
				"/Account/ConfirmEmailChange",
				pageHandler: null,
				values: new { area = "Identity", userId = id, email = email, code = code },
				protocol: Request.Scheme);

			// Send the email
			var emailContent = $"Please confirm your email change by clicking <a href='{callbackUrl}'>here</a>.";
			await _emailSender.SendEmailAsync(email, "Confirm Email Change", emailContent);

			return Json(new { status = true, message = "Email xác nhận đã được gửi. Hãy kiểm tra hộp thư của bạn !" });
		}

		[HttpGet]
		public async Task<JsonResult> SendEmailConfirmation(string id)
		{
			var user = await _userManager.FindByIdAsync(id);
			if (user == null)
			{
				return Json(new { status = false, message = "Không tìm thấy người dùng !" });
			}

			var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
			code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
			var callbackUrl = Url.Page(
				"/Account/ConfirmEmail",
				pageHandler: null,
				values: new { area = "Identity", userId = id, code = code },
				protocol: Request.Scheme);
			await _emailSender.SendEmailAsync(
				user.Email, "Xác nhận Email của bạn",
				$"Vui lòng xác nhận tài khoản tại đây <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

			return Json(new { status = true, message = "Email xác nhận đã được gửi. Hãy kiểm tra hộp thư của bạn !" });
		}

		[Authorize(Roles = "Admin,SuperAdmin")]
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
