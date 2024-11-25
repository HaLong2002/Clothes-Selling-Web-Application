using System.ComponentModel.DataAnnotations;

namespace Website_ASP.NET_Core_MVC.Areas.Admin.Models
{
	public class CreateAccountClient
	{
		[Required(ErrorMessage = "Email không được để trống")]
		[EmailAddress(ErrorMessage = "Email không hợp lệ")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Họ và tên không được để trống")]
		public string FullName { get; set; }

		[Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
		public string? PhoneNumber { get; set; }

		public string? Address { get; set; }

		public DateTime? Date { get; set; }

		public string? Gender { get; set; }

		[Required(ErrorMessage = "Mật khẩu không được để trống")]
		[StringLength(100, ErrorMessage = "Mật khẩu phải có ít nhất {2} ký tự.", MinimumLength = 6)]
		public string Password { get; set; }

		[Compare("Password", ErrorMessage = "Mật khẩu không khớp")]
		public string ConfirmPassword { get; set; }
	}
}
