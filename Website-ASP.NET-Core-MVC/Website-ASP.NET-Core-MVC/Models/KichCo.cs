using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Website_ASP.NET_Core_MVC.Models
{
	[Table("KichCo")]
	public partial class KichCo
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public KichCo()
		{
			SanPhamChiTiets = new HashSet<SanPhamChiTiet>();
		}

		[Key]
		public int MaKichCo { get; set; }

		[Required]
		[StringLength(10)]
		public string TenKichCo { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[JsonIgnore]
		public virtual ICollection<SanPhamChiTiet> SanPhamChiTiets { get; set; }
	}
}
