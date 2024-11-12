using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Website_ASP.NET_Core_MVC.Models;

namespace Website_ASP.NET_Core_MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

		//public DbSet<Customer> Customers { get; set; } // Add your DbSets here

		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	modelBuilder.Entity<Customer>()
		//		.HasIndex(u => u.UserName)
		//		.IsUnique();

		//	modelBuilder.Entity<Customer>()
		//		.HasIndex(u => u.Email)
		//		.IsUnique();
		//}

		public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
		public virtual DbSet<DanhMuc> DanhMucs { get; set; }
		public virtual DbSet<HoaDon> HoaDons { get; set; }
		public virtual DbSet<KichCo> KichCoes { get; set; }
		public virtual DbSet<SanPham> SanPhams { get; set; }
		public virtual DbSet<SanPhamChiTiet> SanPhamChiTiets { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<ChiTietHoaDon>()
				.HasKey(c => new { c.MaHD, c.IDCTSP });

			modelBuilder.Entity<ChiTietHoaDon>()
				.Property(e => e.GiaMua)
				.HasPrecision(19, 4);

			modelBuilder.Entity<HoaDon>()
				.Property(e => e.SoDienThoaiNhan)
				.IsFixedLength()
				.IsUnicode(false);

			// Configuring the foreign key relationship between SanPham and DanhMuc
			modelBuilder.Entity<SanPham>()
				.HasOne(sp => sp.DanhMuc)  // The navigation property in SanPham
				.WithMany(dm => dm.SanPhams)  // The navigation property in DanhMuc
				.HasForeignKey(sp => sp.MaDM)  // The foreign key property in SanPham
				.OnDelete(DeleteBehavior.Cascade);  // Optional: specify delete behavior (cascade, restrict, etc.)

			// Example of configuring other properties
			modelBuilder.Entity<SanPham>()
				.Property(e => e.Gia)
				.HasPrecision(19, 4);  // Precision for the decimal property Gia

			modelBuilder.Entity<SanPham>()
				.Property(e => e.MaMau)
				.IsFixedLength()
				.IsUnicode(false);
		}
	}
}
