using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Website_ASP.NET_Core_MVC.ViewModels
{
	public class RegisterViewModel
	{
		public int Id { get; set; }

		[Display(Name = "Tên đăng nhập")]
		[Required(ErrorMessage = "Tên đăng nhập là bắt buộc")]
		[MaxLength(20, ErrorMessage = "Tối đa 20 kí tự")]
		public string UserName { get; set; }

		[Display(Name = "Email")]
		[Required(ErrorMessage = "Email là bắt buộc")]
		[EmailAddress(ErrorMessage = "Email không đúng định dạng")]
		public string Email { get; set; }

		[Display(Name = "Mật khẩu")]
		[Required(ErrorMessage = "Mật khẩu là bắt buộc")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Nhập lại mật khẩu")]
		[Required(ErrorMessage = "Vui lòng nhập lại mật khẩu")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Mật khẩu không khớp")]
		public string ConfirmPassword { get; set; }

		[Display(Name = "Điện thoại")]
		[Required(ErrorMessage = "Số điện thoại là bắt buộc")]
		[RegularExpression(@"^(\d{10})$", ErrorMessage = "Số điện thoại không hợp lệ")]
		public string Phone { get; set; }

		[Display(Name = "Họ và tên")]
		[Required(ErrorMessage = "Họ và tên là bắt buộc")]
		[MaxLength(50, ErrorMessage = "Tối đa 50 kí tự")]
		public string FullName { get; set; }

		public string? Gender { get; set; }

		[Display(Name = "Ngày sinh")]
		public DateTime? Date { get; set; }

		[Display(Name = "Địa chỉ")]
		[Required(ErrorMessage = "Địa chỉ là bắt buộc")]
		public string Address { get; set; }
	}
}
