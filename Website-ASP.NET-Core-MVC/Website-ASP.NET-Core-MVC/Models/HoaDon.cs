using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Website_ASP.NET_Core_MVC.Models
{
	[Table("HoaDon")]
	public partial class HoaDon
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public HoaDon()
		{
			ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
		}

		[Key]
		public int MaHD { get; set; }

		[Required]
		public string MaTK { get; set; }

		public DateTime NgayDat { get; set; }

		[Column(TypeName = "ntext")]
		public string GhiChu { get; set; }

		public int TrangThai { get; set; }

		[Required]
		[StringLength(100)]
		public string DiaChiNhan { get; set; }

		[Required]
		[StringLength(11)]
		public string SoDienThoaiNhan { get; set; }

		public DateTime? NgaySua { get; set; }

		[StringLength(100)]
		public string NguoiSua { get; set; }

		[Required]
		[StringLength(100)]
		public string HoTenNguoiNhan { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        [ForeignKey("MaTK")]
        public virtual User User { get; set; }
	}
}
