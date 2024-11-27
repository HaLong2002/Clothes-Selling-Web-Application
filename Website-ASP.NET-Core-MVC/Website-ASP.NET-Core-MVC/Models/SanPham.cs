﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Website_ASP.NET_Core_MVC.Models
{
	[Table("SanPham")]
	public partial class SanPham
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public SanPham()
		{
			SanPhamChiTiets = new HashSet<SanPhamChiTiet>();
		}

		[Key]
		public int MaSP { get; set; }

		[ForeignKey("DanhMuc")]
		public int MaDM { get; set; }

		[Required]
		[StringLength(150)]
		public string TenSP { get; set; }

		[Column(TypeName = "money")]
		public decimal Gia { get; set; }

		[Column(TypeName = "ntext")]
		[Required]
		public string MoTa { get; set; }

		[Required]
		[StringLength(50)]
		public string ChatLieu { get; set; }

		[Column(TypeName = "ntext")]
		[Required]
		public string HuongDan { get; set; }

		public DateTime NgayTao { get; set; }

		[Required]
		[StringLength(100)]
		public string NguoiTao { get; set; }

		public DateTime NgaySua { get; set; }

		[Required]
		[StringLength(100)]
		public string NguoiSua { get; set; }

		[Required]
		[StringLength(10)]
		public string MaMau { get; set; }

		[Required]
		[StringLength(150)]
		public string HinhAnh { get; set; }

        //[JsonIgnore]
        public virtual DanhMuc DanhMuc { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<SanPhamChiTiet> SanPhamChiTiets { get; set; }
	}
}
