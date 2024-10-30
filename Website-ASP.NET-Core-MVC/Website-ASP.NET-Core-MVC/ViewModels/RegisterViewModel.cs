using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Website_ASP.NET_Core_MVC.ViewModels
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
		[MaxLength(20, ErrorMessage = "Tối đa 20 kí tự")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập email")]
		[EmailAddress(ErrorMessage = "Email không đúng định dạng")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
		[StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be at {2} and at max {1} characters long")]
		[DataType(DataType.Password)]
		[Compare("ConfirmPassword", ErrorMessage = "Mật khẩu không khớp")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập lại mật khẩu")]
		[DataType(DataType.Password)]
		[Display(Name = "Xác nhận mật khẩu")]
		public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
		[RegularExpression(@"^(\d{10})$", ErrorMessage = "Số điện thoại không hợp lệ")]
		public string Phone { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập họ và tên")]
		[MaxLength(50, ErrorMessage = "Tối đa 50 kí tự")]
		public string FullName { get; set; }

		public string? Gender { get; set; }

		public IEnumerable<SelectListItem> GenderOptions { get; set; } = new List<SelectListItem>
	{
		new SelectListItem { Value = "Nữ", Text = "Nữ" },
		new SelectListItem { Value = "Nam", Text = "Nam" },
		new SelectListItem { Value = "Khác", Text = "Khác" }
	};

		[DataType(DataType.Date)] // Specify date only, no time
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
		public DateTime? Date { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
		public string Address { get; set; }
	}
}
