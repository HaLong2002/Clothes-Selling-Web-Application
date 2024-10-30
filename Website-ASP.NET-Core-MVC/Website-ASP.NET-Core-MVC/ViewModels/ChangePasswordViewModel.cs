using System.ComponentModel.DataAnnotations;

namespace Website_ASP.NET_Core_MVC.ViewModels
{
	public class ChangePasswordViewModel
	{
		[Required(ErrorMessage = "Vui lòng nhập email")]
		[EmailAddress]
		public string Email { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
		[StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be at {2} and at max {1} characters long")]
		[DataType(DataType.Password)]
		[Display(Name = "Mật khẩu mới")]
		[Compare("ConfirmNewPassword", ErrorMessage = "Mật khẩu không khớp")]
		public string NewPassword { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập lại mật khẩu")]
		[DataType(DataType.Password)]
		[Display(Name = "Xác nhận mật khẩu mới")]
		public string ConfirmNewPassword { get; set; }
	}
}
