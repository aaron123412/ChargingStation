using ChargingStationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChargingStationAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ChargingStation> ChargingStations { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
