using Domain;
using Microsoft.EntityFrameworkCore;

namespace Presistance
{
    public class DataContext : DbContext
    {
        public DataContext(){

        }
        public DataContext(DbContextOptions options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
         protected override void OnConfiguring(DbContextOptionsBuilder options)
         {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("A FALLBACK CONNECTION STRING");
            }
        }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
                        .HasOne(c => c.Categories)
                        .WithMany(p => p.Products)
                        .HasForeignKey("CategoryId");

            modelBuilder.Entity<Categories>()
                        .HasData(
                            new Categories() { Id = Guid.NewGuid(), Name = "Mobiles" },
                            new Categories() { Id = Guid.NewGuid(), Name = "Watches" }
                        );

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}