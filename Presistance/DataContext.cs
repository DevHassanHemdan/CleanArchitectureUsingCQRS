using Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

            //modelBuilder.Entity<Categories>()
            //            .HasData(
            //                new Categories() { Id = Guid.NewGuid(), Name = "Mobiles" },
            //                new Categories() { Id = Guid.NewGuid(), Name = "Watches" }
            //            );
            modelBuilder.Entity<ProductBrand>().HasKey(x => x.Id);
            modelBuilder.Entity<ProductType>().HasKey(x => x.Id);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}