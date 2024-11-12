using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Website_ASP.NET_Core_MVC.Models
{
	[Table("ChiTietHoaDon")]
	public partial class ChiTietHoaDon
	{
		[Key]
		[Column(Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int MaHD { get; set; }

		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int IDCTSP { get; set; }

		public int SoLuongMua { get; set; }

		[Column(TypeName = "money")]
		public decimal GiaMua { get; set; }

		public virtual SanPhamChiTiet SanPhamChiTiet { get; set; }

		[JsonIgnore]
		public virtual HoaDon HoaDon { get; set; }
	}
}
