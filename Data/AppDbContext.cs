using Microsoft.EntityFrameworkCore;
using FoodOrderingApp.Models;

namespace FoodOrderingApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Addon> Addons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderAddon> OrderedAddons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderAddon>()
                .HasKey(oa => new { oa.OrderId, oa.AddonId });

            modelBuilder.Entity<OrderAddon>()
                .HasOne(oa => oa.Order)
                .WithMany(o => o.OrderAddons)
                .HasForeignKey(oa => oa.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderAddon>()
                .HasOne(oa => oa.Addon)
                .WithMany(a => a.OrderAddons)
                .HasForeignKey(oa => oa.AddonId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Restaurant)
                .WithMany()
                .HasForeignKey(o => o.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
