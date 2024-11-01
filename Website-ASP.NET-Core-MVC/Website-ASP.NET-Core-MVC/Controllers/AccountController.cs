using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Text.Encodings.Web;
using Website_ASP.NET_Core_MVC.Models;
using Website_ASP.NET_Core_MVC.Services;
using Website_ASP.NET_Core_MVC.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Website_ASP.NET_Core_MVC.Controllers
{
	public class AccountController : Controller
	{
		private readonly SignInManager<User> _signInManager;
		private readonly UserManager<User> _userManager;
		private readonly IEmailSender _emailSender;

		public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, IEmailSender emailSender)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_emailSender = emailSender;
		}

		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}
				else if (result.IsNotAllowed)
				{
					ModelState.AddModelError("", "Email " + model.Email + " chưa được xác nhận.\n Vui lòng kiểm tra lại mail của chúng tôi đã gửi cho bạn.");
					return View(model);
				}
				else
				{
					ModelState.AddModelError("", "Email hoặc mật khẩu không đúng");
					return View(model);
				}
			}
			return View(model);
		}

		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				User user = new User
				{
					FullName = model.Name,
					Email = model.Email,
					UserName = model.Email,
				};

				var result = await _userManager.CreateAsync(user, model.Password);

				if (result.Succeeded)
				{
					await SendConfirmationEmail(model.Email, user);
					return View("RegistrationSuccessful");
					//return RedirectToAction("Login", "Account");
				}
				else
				{
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}

					return View(model);
				}
			}
			return View(model);
		}

		private async Task SendConfirmationEmail(string? email, User? user)
		{
			//Generate the Token
			var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

			//Build the Email Confirmation Link which must include the Callback URL
			var ConfirmationLink = Url.Action("ConfirmEmail", "Account",
			new { UserId = user.Id, Token = token }, protocol: HttpContext.Request.Scheme);

			//Send the Confirmation Email to the User Email Id
			await _emailSender.SendEmailAsync(email, "Xác nhận Email của bạn", $"Vui lòng xác nhận tài khoản tại đây <a href='{HtmlEncoder.Default.Encode(ConfirmationLink)}'>clicking here</a>.");
		}

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string UserId, string Token)
        {
            if (UserId == null || Token == null)
            {
                ViewBag.Message = "Đường link không hợp lệ hoặc đã hết hiệu lực";
            }

            //Find the User By Name
            var user = await _userManager.FindByEmailAsync(UserId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"ID người dùng: {UserId} không hợp lệ";
                return View("NotFound");
            }

            //Call the ConfirmEmailAsync Method which will mark the Email as Confirmed
            var result = await _userManager.ConfirmEmailAsync(user, Token);
            if (result.Succeeded)
            {
                ViewBag.Message = "Cảm ơn bạn đã xác nhận email của bạn";
                return View();
            }

            ViewBag.Message = "Email không thể được xác nhận";
            return View();
        }

        public IActionResult VerifyEmail()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> VerifyEmail(VerifyEmailViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByNameAsync(model.Email);

				if (user == null)
				{
					ModelState.AddModelError("", "Email không được tìm thấy!");
					return View(model);
				}
				else
				{
					return RedirectToAction("ChangePassword", "Account", new { username = user.UserName });
				}
			}
			return View(model);
		}

		public IActionResult ChangePassword(string username)
		{
			if (string.IsNullOrEmpty(username))
			{
				return RedirectToAction("VerifyEmail", "Account");
			}
			return View(new ChangePasswordViewModel { Email = username });
		}

		[HttpPost]
		public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByNameAsync(model.Email);

				if (user != null)
				{
					var result = await _userManager.RemovePasswordAsync(user);

					if (result.Succeeded)
					{
						result = await _userManager.AddPasswordAsync(user, model.NewPassword);
						return RedirectToAction("Login", "Account");
					}
					else
					{
						foreach (var error in result.Errors)
						{
							ModelState.AddModelError("", error.Description);
						}

						return View(model);
					}
				}
				else
				{
					ModelState.AddModelError("", "Email không được tìm thấy!");
					return View(model);
				}
			}
			else
			{
				ModelState.AddModelError("", "Có gì đó không đúng. Hãy thử lại.");
				return View(model);
			}
		}

		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
	}
}
