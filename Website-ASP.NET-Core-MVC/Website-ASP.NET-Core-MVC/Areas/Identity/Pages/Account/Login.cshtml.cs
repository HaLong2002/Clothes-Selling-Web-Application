// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Website_ASP.NET_Core_MVC.Models;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Website_ASP.NET_Core_MVC.Areas.Identity.Pages.Account
{
	public class LoginModel : PageModel
	{
		private readonly SignInManager<User> _signInManager;
		private readonly ILogger<LoginModel> _logger;
		private readonly UserManager<User> _userManager;

		public LoginModel(SignInManager<User> signInManager, ILogger<LoginModel> logger, UserManager<User> userManager)
		{
			_signInManager = signInManager;
			_logger = logger;
			_userManager = userManager;
		}

		[BindProperty]
		public InputModel Input { get; set; }

		public IList<AuthenticationScheme> ExternalLogins { get; set; }

		public string ReturnUrl { get; set; }

		[TempData]
		public string ErrorMessage { get; set; }

		public bool IsUnconfirmedEmail { get; set; }

		public class InputModel
		{
			[Required(ErrorMessage = "Vui lòng nhập email")]
			[EmailAddress]
			public string Email { get; set; }

			[Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
			[DataType(DataType.Password)]
			[Display(Name = "Mật khẩu")]
			public string Password { get; set; }

			[Display(Name = "Nhớ đăng nhập?")]
			public bool RememberMe { get; set; }
		}

		public async Task OnGetAsync(string returnUrl = null)
		{
			if (!string.IsNullOrEmpty(ErrorMessage))
			{
				ModelState.AddModelError(string.Empty, ErrorMessage);
			}

			returnUrl ??= Url.Content("~/");

			// Clear the existing external cookie to ensure a clean login process
			await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

			ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

			ReturnUrl = returnUrl;
		}
		
		public async Task<IActionResult> OnPostAsync(string returnUrl = null)
		{
			returnUrl ??= Url.Content("~/");

			//ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

			if (ModelState.IsValid)
			{
				var username = Input.Email;

				//var result = await _signInManager.PasswordSignInAsync(username, Input.Password, Input.RememberMe, lockoutOnFailure: true);
				var result = await _signInManager.PasswordSignInAsync(username, Input.Password, true, lockoutOnFailure: true);
				if (result.Succeeded)
				{
					_logger.LogInformation("User logged in.");

					var user = await _userManager.FindByEmailAsync(username);

					var roles = await _userManager.GetRolesAsync(user);

					// Kiểm tra xem người dùng có vai trò 'Customer' không
					if (roles.Contains("Customer"))
					{
						return LocalRedirect(returnUrl); // Trở lại trang trước đó nếu là Customer
					}
					else
					{
						// Nếu không phải Customer, chuyển hướng đến trang Admin
						return RedirectToAction("Index", "Home", new { area = "Admin" });
					}
				}

				if (result.IsLockedOut)
				{
					_logger.LogWarning("Tài khoản của bạn đã bị khóa.");
					ModelState.AddModelError(string.Empty, "Tài khoản của bạn đã bị khóa. Vui lòng thử lại sau 5 phút.");
					//return RedirectToPage("./Lockout");
					return Page();
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Không thể đăng nhập. \nVui lòng kiểm tra thông tin đăng nhập của bạn và đảm bảo tài khoản của bạn đã được xác nhận.");
					return Page();
				}
			}

			return Page();
		}
	}
}
