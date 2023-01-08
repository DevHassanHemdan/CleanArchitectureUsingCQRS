using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Presistance
{
    public class DbInitializer
    {
        public static async Task SeedData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                DataContext context = serviceScope.ServiceProvider.GetService<DataContext>();
                UserManager<Users> userManager = serviceScope.ServiceProvider.GetService<UserManager<Users>>();

                if (!await userManager.Users.AnyAsync())
                {
                    List<Users> users = new List<Users>()
                    {
                        new Users()
                        {
                            Id = Guid.NewGuid().ToString(),
                            FirstName= "Hassan",
                            LastName ="Hemdan",
                            Email="hassanhemdan92@gmail.com",
                            UserName = "Hassan Hemdan",
                            Address = "Cairo",
                            NormalizedUserName = "Hassan Hemdan"
                        },
                        new Users()
                        {
                            Id = Guid.NewGuid().ToString(),
                            FirstName= "Ali",
                            LastName ="Fathi",
                            Email="AliFathi@gmail.com",
                            UserName = "Ali Fathi",
                            Address = "Alex",
                            NormalizedUserName = "Ali Fathi"
                        },
                        new Users()
                        {
                            Id = Guid.NewGuid().ToString(),
                            FirstName= "Ahmed",
                            LastName ="Ali",
                            Email="AAli@gmail.com",
                            UserName = "Ahmed Ali",
                            Address = "Giza",
                            NormalizedUserName = "Ahmed Ali"
                        }
                    };
                    foreach (Users user in users)
                    {
                        await userManager.AddPasswordAsync(user, "P@ssw0rd");
                        await context.Users.AddAsync(user);
                    }
                }

                if (!context.Categories.Any())
                {
                    List<Categories> categories = new List<Categories>()
                        {
                            new Categories()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Mobiles"
                            }, new Categories()
                            {
                                 Id = Guid.NewGuid(),
                                Name = "Tvs"
                            }, new Categories()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Watches"
                            }

                        };
                    await context.Categories.AddRangeAsync(categories);
                }

                if (!context.ProductBrands.Any())
                {
                    List<ProductBrand> productBrands = new List<ProductBrand>()
                        {
                            new ProductBrand()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Apple"
                            }, new ProductBrand()
                            {
                                 Id = Guid.NewGuid(),
                                Name = "Samsung"
                            }, new ProductBrand()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Nokia"
                            }

                        };
                    await context.ProductBrands.AddRangeAsync(productBrands);
                }

                if (!context.ProductTypes.Any())
                {
                    List<ProductType> productTypes = new List<ProductType>()
                        {
                            new ProductType()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Type 1"
                            }, new ProductType()
                            {
                                 Id = Guid.NewGuid(),
                                Name = "Type 2"
                            }, new ProductType()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Type 3"
                            }

                        };
                    await context.ProductTypes.AddRangeAsync(productTypes);
                }
                
                await context.SaveChangesAsync();
            }
        }
    }
}

