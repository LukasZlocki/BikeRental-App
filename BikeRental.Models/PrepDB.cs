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
        }
    }
}