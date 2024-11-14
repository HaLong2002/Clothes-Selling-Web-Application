using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Website_ASP.NET_Core_MVC.Models
{
    public class User : IdentityUser
	{
		public string FullName { get; set; }
		public string? Gender { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
		public DateTime? Date { get; set; }
		public string? Address { get; set; }
		public string? Image { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }

    }
}
