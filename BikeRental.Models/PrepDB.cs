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
        }
    }
}