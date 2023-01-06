using Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Presistance
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

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
            modelBuilder.Entity<ProductBrand>().HasKey(x => x.Id);

            modelBuilder.Entity<ProductType>().HasKey(x => x.Id);

            modelBuilder.Entity<Product>()
                       .HasOne(e => e.ProductBrand)
                       .WithMany(c => c.Products);

            modelBuilder.Entity<Product>()
                       .HasOne(e => e.ProductType)
                       .WithMany(c => c.Products);

            modelBuilder.Entity<Categories>()
                        .HasMany(p => p.Products)
                        .WithOne(c => c.Categories)
                        .HasForeignKey(c => c.CategoriesId);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Categories>()
                .HasData(new Categories
                {
                    Id = Guid.NewGuid(),
                    Name = "Mobiles"
                }, new Categories
                {
                    Id = Guid.NewGuid(),
                    Name = "Tvs"
                }, new Categories
                {
                    Id = Guid.NewGuid(),
                    Name = "Watches"
                });

            modelBuilder.Entity<ProductType>()
                .HasData(new ProductType
                {
                    Id = Guid.NewGuid(),
                    Name = "ProductType 1"
                }, new ProductType
                {
                    Id = Guid.NewGuid(),
                    Name = "ProductType 2"
                }, new ProductType
                {
                    Id = Guid.NewGuid(),
                    Name = "ProductType 3"
                });

            modelBuilder.Entity<ProductBrand>()
                .HasData(new ProductBrand
                {
                    Id = Guid.NewGuid(),
                    Name = "Apple"
                }, new ProductBrand
                {
                    Id = Guid.NewGuid(),
                    Name = "Samsung"
                }, new ProductBrand
                {
                    Id = Guid.NewGuid(),
                    Name = "Nokia"
                });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}