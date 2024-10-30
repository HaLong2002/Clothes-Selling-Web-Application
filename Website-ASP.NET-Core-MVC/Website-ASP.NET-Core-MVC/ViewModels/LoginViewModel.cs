using System.ComponentModel.DataAnnotations;

namespace Website_ASP.NET_Core_MVC.ViewModels
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Vui lòng nhập email")]
		[EmailAddress]
		public string Email { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập password")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Remember me?")]
		public bool RememberMe { get; set; }
	}
}
