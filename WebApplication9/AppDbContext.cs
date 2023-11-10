using Microsoft.EntityFrameworkCore;
using WebApplication9.Models;
using WebApplication9.Services;

namespace WebApplication9
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<InventoryModel> Inventory { get; set; }
        public DbSet<CategoryModel> category { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<InventoryModel>()
                .HasOne(i => i.Category)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.CategoryId);

           
            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel { Id = 1, CategoryName = "exp" },
                new CategoryModel { Id = 2, CategoryName = "edsd" }
            );
        }
    }
}
