using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Website_ASP.NET_Core_MVC.Models
{

	[Table("SanPhamChiTiet")]
	public partial class SanPhamChiTiet
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public SanPhamChiTiet()
		{
			ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
		}

		[Key]
		public int IDCTSP { get; set; }

		public int MaSP { get; set; }

		public int MaKichCo { get; set; }

		public int SoLuong { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[JsonIgnore]
		public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

		public virtual KichCo KichCo { get; set; }

		[JsonIgnore]
		public virtual SanPham SanPham { get; set; }
	}
}
