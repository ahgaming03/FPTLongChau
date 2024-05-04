using FPTLongChau.Areas.Admin.Models;
using FPTLongChau.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FPTLongChau.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<ApplicationUser> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Rank> Ranks { get; set; }
		public DbSet<Supplier> Suppliers { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
		public DbSet<Unit> Units { get; set; }
		public DbSet<Storage> Storages { get; set; }
		public DbSet<ShipMode> ShipModes { get; set; }
		public DbSet<DeliveryInformation> DeliveryInformations { get; set; }
		public DbSet<PayMode> PayModes { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			/* Order detail */
			modelBuilder.Entity<OrderDetail>()
				.HasKey(od => new { od.OrderId, od.ProductId }); // Composite key

			modelBuilder.Entity<OrderDetail>()
				.HasOne(od => od.Order)
				.WithMany(o => o.OrderDetails)
				.HasForeignKey(od => od.OrderId);

			modelBuilder.Entity<OrderDetail>()
				.HasOne(od => od.Product)
				.WithMany(p => p.OrderDetails)
				.HasForeignKey(od => od.ProductId);
		}
	}
}
