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
					var resendLink = Url.Action("ResendConfirmationEmail", "Account");
					ModelState.AddModelError("", $"Email chưa được xác nhận. Vui lòng kiểm tra email của bạn để xác nhận hoặc <a href='{resendLink}'> nhấn vào đây để gửi lại</a>.");
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

				var checkEmail = await _userManager.FindByEmailAsync(model.Email);
				if (checkEmail != null)
				{
					ModelState.AddModelError("", "Email đã được dùng");
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

			//Find the User By Id
			var user = await _userManager.FindByIdAsync(UserId);
			if (user == null)
			{
				ViewBag.ErrorMessage = $"ID người dùng: {UserId} không hợp lệ";
				return View("NotFound");
			}

			//Call the ConfirmEmailAsync Method which will mark the Email as Confirmed
			var result = await _userManager.ConfirmEmailAsync(user, Token);
			if (result.Succeeded)
			{
				ViewBag.Message = "Cảm ơn bạn đã xác nhận email";
				return View();
			}

			ViewBag.Message = "Email không thể được xác nhận";
			return View();
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult ResendConfirmationEmail(bool IsResend = true)
		{
			if (IsResend)
			{
				ViewBag.Message = "Gửi lại Email xác nhận";
			}
			else
			{
				ViewBag.Message = "Đã gửi Email xác nhận";
			}
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ResendConfirmationEmail(string Email)
		{
			var user = await _userManager.FindByEmailAsync(Email);
			if (user == null || await _userManager.IsEmailConfirmedAsync(user))
			{
				// Handle the situation when the user does not exist or Email already confirmed.
				// For security, don't reveal that the user does not exist or Email is already confirmed
				return View("ConfirmationEmailSent");
			}

			//Then send the Confirmation Email to the User
			await SendConfirmationEmail(Email, user);

			return View("ConfirmationEmailSent");
		}

		[AllowAnonymous]
		public IActionResult ForgetPassword()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(model.Email);

				if (user == null)
				{
					// Don't reveal that the user does not exist or is not confirmed
					return View("ForgetPasswordConfirmation");
				}
				else
				{
					// Send an email with this link
					string code = await _userManager.GeneratePasswordResetTokenAsync(user);
					var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
					await _emailSender.SendEmailAsync(user.Id, "Đặt lại mật khẩu của bạn", "Vui lòng đặt lại mật khẩu của bạn bằng cách nhấn vào link sau <a href=\"" + callbackUrl + "\">here</a>");

					return RedirectToAction("ForgetPasswordConfirmation", "Account");

					//bool IsSendEmail = _emailSender.EmailSend(model.Email, "Đặt lại mật khẩu của bạn", "Vui lòng đặt lại mật khẩu của bạn bằng cách nhấn vào link sau <a href=\"" + callbackUrl + "\">here</a>", true);
					//if (IsSendEmail)
					//{
					//	return RedirectToAction("ForgetPasswordConfirmation", "Account");
					//}
				}
			}
			return View(model);
		}

		[AllowAnonymous]
		public ActionResult ForgetPasswordConfirmation()
		{
			return View();
		}

        [AllowAnonymous]
        public IActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var user = await _userManager.FindByEmailAsync(model.Email);
			if (user == null)
			{
				// Don't reveal that the user does not exist
				return RedirectToAction("ResetPasswordConfirmation", "Account");
			}
			var result = await _userManager.ResetPasswordAsync(user, model.Code, model.NewPassword);
			//var result =  UserManager.ResetPassword(user.Id, model.Code, model.Password);
			if (result.Succeeded)
			{
				return RedirectToAction("ResetPasswordConfirmation", "Account");
			}
			//AddErrors(result);
			return View("Error");
			//return View();
		}

		//============================================================================

		private async Task SendPasswordResetEmail(string? email, User? user)
		{
			//Generate the Token
			var token = await _userManager.GeneratePasswordResetTokenAsync(user);
			var encodedToken = Encoding.UTF8.GetBytes(token);
			var validToken = WebEncoders.Base64UrlEncode(encodedToken);

			//Build the reset Link which must include the Callback URL
			var ResetLink = Url.Action("ResetPassword", "Account",
			new { Email = email, Token = validToken }, protocol: HttpContext.Request.Scheme);

			//Send the Confirmation Email to the User Email Id
			await _emailSender.SendEmailAsync(email, "Đặt lại mật khẩu", $"Vui lòng đặt lại mật khẩu của bạn tại đây <a href='{HtmlEncoder.Default.Encode(ResetLink)}'>clicking here</a>.");
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> ResetPassword(string Email, string Token, ResetPasswordViewModel model)
		{
			if (Email == null || Token == null)
			{
				ViewBag.Message = "Đường link không hợp lệ hoặc đã hết hiệu lực";
			}

			//Find the User By Email
			var user = await _userManager.FindByEmailAsync(Email);
			if (user == null)
			{
				ViewBag.ErrorMessage = $"Email: {Email} không hợp lệ";
				return View("NotFound");
			}

			if (ModelState.IsValid)
			{
				//Call the ResetPasswordAsync Method
				var result = await _userManager.ResetPasswordAsync(user, Token, model.NewPassword);
				if (result.Succeeded)
				{
					ViewBag.Message = "Đặt lại mật khẩu thành công!";
					return RedirectToAction("Login", "Account");
					//return View();
				}
			}
			else
			{
				ModelState.AddModelError("", "Có gì đó không đúng. Hãy thử lại.");
				return View(model);
			}

			ViewBag.Message = "Không thể đặt lại mật khẩu";
			return View();
		}


		public IActionResult ChangePassword(string username)
		{
			if (string.IsNullOrEmpty(username))
			{
				return RedirectToAction("VerifyEmail", "Account");
			}
			return View(new ResetPasswordViewModel { Email = username });
		}

		[HttpPost]
		public async Task<IActionResult> ChangePassword(ResetPasswordViewModel model)
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
