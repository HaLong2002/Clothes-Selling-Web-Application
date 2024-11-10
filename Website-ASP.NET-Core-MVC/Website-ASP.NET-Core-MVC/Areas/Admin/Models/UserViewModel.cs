using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Website_ASP.NET_Core_MVC.Areas.Identity.Pages.Account.Manage.IndexModel;

namespace Website_ASP.NET_Core_MVC.Areas.Admin.Models
{
	public class UserViewModel
	{
		public string UserId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên của bạn")]
        [MaxLength(20, ErrorMessage = "Tối đa 20 kí tự")]
        [Display(Name = "Tên")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Số điện thoại")] 
		public string? Phone { get; set; }

        [Display(Name = "Giới tính")]
        public string? Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")] // Change format to yyyy-MM-dd
        [Display(Name = "Ngày sinh")]
        public DateTime? Date { get; set; }

        [Display(Name = "Địa chỉ")]
        public string? Address { get; set; }

        [Display(Name = "Ảnh đại diện")]
        [DataType(DataType.Upload)]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        public string? Image { get; set; }

		public IEnumerable<string> Roles { get; set; }
	}
}
