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
            // modelBuilder.Entity<Product>()
            //             .HasData(
            //                 new Product() {Id = Guid.NewGuid(), CategoryId = Guid.Parse("E9CB6664-EF95-4C14-BFA0-1A3247F09C63"), Name = "Iphone 13 pro max", Price = 36000 },
            //                 new Product() {Id = Guid.NewGuid(), CategoryId = Guid.Parse("E9CB6664-EF95-4C14-BFA0-1A3247F09C63"), Name = "Samsung S22", Price = 21000 },
            //                 new Product() {Id = Guid.NewGuid(), CategoryId = Guid.Parse("75AA1F9F-9C21-4B82-B1BF-2499A4095A8D"), Name = "Apple watch", Price = 10000 }
            //             );

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}