// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Website_ASP.NET_Core_MVC.Models;

namespace Website_ASP.NET_Core_MVC.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ExternalLoginModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        //private readonly IUserStore<User> _userStore;
        //private readonly IUserEmailStore<User> _emailStore;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<ExternalLoginModel> _logger;

        public ExternalLoginModel(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IUserStore<User> userStore,
            ILogger<ExternalLoginModel> logger,
            IEmailSender emailSender)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            //_userStore = userStore;
            //_emailStore = GetEmailStore();
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ProviderDisplayName { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            public string FullName { get; set; }

        }

        public IActionResult OnGet() => RedirectToPage("./Login");

        public IActionResult OnPost(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Page("./ExternalLogin", pageHandler: "Callback", values: new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> OnGetCallbackAsync(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (remoteError != null)
            {
                ErrorMessage = $"Lỗi từ nhà cung cấp bên ngoài: {remoteError}";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ErrorMessage = "Có lỗi khi tải thông tin đăng nhập bên ngoài.";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }

            // Đăng nhập nếu tài khoản đã tồn tại và đã liên kết với nhà cung cấp
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: true, bypassTwoFactor: true);
            if (result.Succeeded)
            {
                _logger.LogInformation("{Name} đã đăng nhập bằng nhà cung cấp {LoginProvider}.", info.Principal.Identity.Name, info.LoginProvider);
                return LocalRedirect(returnUrl);
            }

            if (result.IsLockedOut)
            {
                return RedirectToPage("./Lockout");
            }
            else
            {
                var user1 = await _userManager.FindByEmailAsync(info.Principal.FindFirstValue(ClaimTypes.Email));
                if (user1 != null)
                {
                    // Nếu tài khoản đã đăng ký bằng mật khẩu nhưng chưa liên kết với Google
                    var logins = await _userManager.GetLoginsAsync(user1);
                    if (logins.All(l => l.LoginProvider != info.LoginProvider))
                    {
                        var addLoginResult = await _userManager.AddLoginAsync(user1, info);
                        if (addLoginResult.Succeeded)
                        {
                            _logger.LogInformation("Tài khoản {Email} đã được liên kết với nhà cung cấp {LoginProvider}.", user1.Email, info.LoginProvider);

                            // Cập nhật EmailConfirmed = true
                            user1.EmailConfirmed = true;
                            await _userManager.UpdateAsync(user1);

                            await _signInManager.SignInAsync(user1, isPersistent: true);
                            return LocalRedirect(returnUrl);
                        }
                        else
                        {
                            foreach (var error in addLoginResult.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                            return Page();
                        }
                    }
                }
                // Nếu tài khoản chưa tồn tại, tạo mới
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                var fullName = info.Principal.FindFirstValue(ClaimTypes.Name);

                if (email == null)
                {
                    ErrorMessage = "Không có email từ nhà cung cấp bên ngoài.";
                    return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
                }

                var user = new User
                {
                    UserName = email,
                    Email = email,
                    FullName = fullName,
                    EmailConfirmed = true,
                };

                var createResult = await _userManager.CreateAsync(user);
                if (createResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Enums.Roles.Customer.ToString());
                    await _userManager.AddLoginAsync(user, info);

                    _logger.LogInformation("Người dùng đã tạo một tài khoản bằng nhà cung cấp {Name}.", info.LoginProvider);

                    await _signInManager.SignInAsync(user, isPersistent: true, info.LoginProvider);
                    return LocalRedirect(returnUrl);
                }

                // Hiển thị lỗi nếu tạo tài khoản không thành công
                foreach (var error in createResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                ProviderDisplayName = info.ProviderDisplayName;
                ReturnUrl = returnUrl;
                return Page();
            }
        }
    }
}
