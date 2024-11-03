using System.ComponentModel.DataAnnotations;

namespace Website_ASP.NET_Core_MVC.ViewModels
{
	public class ResetPasswordViewModel
	{
		public string Code { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập email")]
		[EmailAddress]
		public string Email { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
		[StringLength(40, MinimumLength = 8, ErrorMessage = "{0} phải dài từ {2} đến tối đa {1} ký tự")]
		[DataType(DataType.Password)]
		[Display(Name = "Mật khẩu mới")]
		public string NewPassword { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập lại mật khẩu")]
		[DataType(DataType.Password)]
		[Display(Name = "Xác nhận mật khẩu mới")]
		[Compare("NewPassword", ErrorMessage = "Mật khẩu không khớp")]
		public string ConfirmNewPassword { get; set; }
	}
}
