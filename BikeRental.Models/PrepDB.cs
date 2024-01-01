using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BikeRental.Models{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<RentalDbContext>());
            }
        }

        public static void SeedData(RentalDbContext context)
        {
            System.Console.WriteLine("Appling migrations...");
            context.Database.Migrate();

            if (!context.FrameSizes.Any())
            {
                System.Console.WriteLine("Adding data: Frame sizes - seeding ...");
                context.FrameSizes.AddRange(
                    new Models.FrameSize() { Size = 16},
                    new Models.FrameSize() { Size = 18 },
                    new Models.FrameSize() { Size = 20 },
                    new Models.FrameSize() { Size = 21 }
                    );
            }
            else
            {
                System.Console.WriteLine("Frame size data exist - no need to seed.");
            }

            if (!context.Categorys.Any())
            {
                System.Console.WriteLine("Adding data: Categories - seeding ...");
                context.Categorys.AddRange(
                    new Models.Category() { Type = "MTB" },
                    new Models.Category() { Type = "Gravel" },
                    new Models.Category() { Type = "Kids" },
                    new Models.Category() { Type = "BMX" }
                    );
            }
            else
            {
                System.Console.WriteLine("Categories data exist - no need to seed.");
            }

            if (!context.Bicycles.Any())
            {
                System.Console.WriteLine("Adding data: Bicycles - seeding ...");
                context.Bicycles.AddRange(
                    new Models.Bicycle() { 
                        CategoryId = 1, 
                        ModelName = "Giant Graverel",
                        FrameSizeId = 1,
                        SerialNumber = "B0001",
                        StartService = DateTime.Parse("2023.12.12"),
                        IsAvailable = false,
                        IsInService = true,
                        IsRent = false
                    },
                    new Models.Bicycle()
                    {
                        CategoryId = 0,
                        ModelName = "Giant MTB",
                        FrameSizeId = 2,
                        SerialNumber = "B0002",
                        StartService = DateTime.Parse("2023.12.12"),
                        IsAvailable = true,
                        IsInService = false,
                        IsRent = false
                    });
            }
            else
            {
                System.Console.WriteLine("Bicycles data exist - no need to seed.");
            }
        }
    }
}