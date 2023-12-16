using BikeRental.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BikeRental.Models
{
    public class RentalDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public RentalDbContext()
        {
            
        }

        public RentalDbContext(DbContextOptions<RentalDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Bicycle> Bicycles { get; set; }
        public DbSet<Category> Categorys { get; set; } 
        public DbSet<FrameSize> FrameSizes { get; set; }
        public DbSet<ReservationTicket> ReservationTickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                // Use the connection string from appsettings.json
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);

                optionsBuilder.UseSqlServer(connectionString, options =>
                {
                    // Enable retry on failure
                    options.EnableRetryOnFailure();
                });
            }
        }
    }
}
