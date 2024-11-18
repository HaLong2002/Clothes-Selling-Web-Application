using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Website_ASP.NET_Core_MVC.Areas.Admin.Models;
using Website_ASP.NET_Core_MVC.Models;

namespace Website_ASP.NET_Core_MVC.Areas.Admin.Controllers
{

    public class LoginController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<User> _logger;
        private readonly UserManager<User> _userManager;

        public LoginController(SignInManager<User> signInManager, ILogger<User> logger, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginAccount loginAccount)
        {
            //if (ModelState.IsValid)
            //{
            //    TaiKhoanQuanTri tk = db.TaiKhoanQuanTris.Where(a => a.TenDangNhap.Equals(loginAccount.username)
            //    && a.MatKhau.Equals(loginAccount.password)).SingleOrDefault();

            //    if (tk != null)
            //    {
            //        if (tk.TrangThai == false)
            //        {
            //            ModelState.AddModelError("ErrorLogin", "Tài khoản đã bị vô hiệu hóa! Liên hệ quản trị viên!");
            //        }
            //        else
            //        {
            //            Session.Add(ConstaintUser.ADMIN_SESSION, tk);
            //            return RedirectToAction("Index", "Home");
            //        }
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("ErrorLogin", "Tài khoản hoặc mật khẩu không đúng!");
            //    }
            //}
            //return View(loginAccount);

            if (ModelState.IsValid)
            {
                var username = loginAccount.Email;
                var result = await _signInManager.PasswordSignInAsync(username, loginAccount.Password, loginAccount.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return RedirectToAction("Index", "Home");
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("Tài khoản của bạn đã bị khóa.");
                    ModelState.AddModelError(string.Empty, "Tài khoản của bạn đã bị khóa. Vui lòng thử lại sau 5 phút.");
                    //return RedirectToPage("./Lockout");
                    return View(loginAccount);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Không thể đăng nhập. Vui lòng kiểm tra thông tin đăng nhập của bạn và đảm bảo tài khoản của bạn đã được xác nhận.");
                    return View(loginAccount);
                }
            }
            return View(loginAccount);
        }
    }
}
