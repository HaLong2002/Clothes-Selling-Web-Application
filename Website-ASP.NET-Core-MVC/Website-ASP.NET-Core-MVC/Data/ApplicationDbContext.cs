using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Website_ASP.NET_Core_MVC.Models;

namespace Website_ASP.NET_Core_MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
	{
        public ApplicationDbContext(DbContextOptions options) : base(options) {}

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

	}
}
