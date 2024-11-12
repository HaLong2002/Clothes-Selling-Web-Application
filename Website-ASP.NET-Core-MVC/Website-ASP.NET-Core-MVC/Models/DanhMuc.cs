using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Website_ASP.NET_Core_MVC.Models
{
	[Table("DanhMuc")]
	public partial class DanhMuc
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public DanhMuc()
		{
			SanPhams = new HashSet<SanPham>();
		}

		[Key]
		public int MaDM { get; set; }

		[Required]
		[StringLength(100)]
		public string TenDanhMuc { get; set; }

		public DateTime NgayTao { get; set; }

		[Required]
		[StringLength(100)]
		public string NguoiTao { get; set; }

		public DateTime NgaySua { get; set; }

		[Required]
		[StringLength(100)]
		public string NguoiSua { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[JsonIgnore]
		public virtual ICollection<SanPham> SanPhams { get; set; }
	}
}
