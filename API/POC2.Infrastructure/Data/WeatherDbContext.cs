using Microsoft.EntityFrameworkCore;
using POC2.Domain.Entities;

namespace POC2.Infrastructure.Data
{
    public class WeatherDbContext : DbContext
    {

        public WeatherDbContext(DbContextOptions<WeatherDbContext> options)
            : base(options)
        {
        }
        public DbSet<WeatherData> WeatherData { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Cities> Cities { get; set; }
       
    }
}
