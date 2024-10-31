using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Website_ASP.NET_Core_MVC.ViewModels
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "Vui lòng nhập tên của bạn")]
		[MaxLength(20, ErrorMessage = "Tối đa 20 kí tự")]
		[Display(Name = "Tên của bạn")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập email")]
		[EmailAddress(ErrorMessage = "Email không đúng định dạng")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
		[StringLength(40, MinimumLength = 8, ErrorMessage = "{0} phải dài từ {2} đến tối đa {1} ký tự")]
		[DataType(DataType.Password)]
		[Display(Name = "Mật khẩu")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập lại mật khẩu")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Mật khẩu không khớp")]
		[Display(Name = "Xác nhận mật khẩu")]
		public string ConfirmPassword { get; set; }
	}
}
