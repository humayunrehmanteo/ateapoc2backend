using Microsoft.EntityFrameworkCore;
using SecondTaskWeather.Domain;

namespace SecondTaskWeather.Infrastructure
{
    public class WeatherDBContext: DbContext
    {
        public WeatherDBContext(DbContextOptions<WeatherDBContext> options)
            : base(options)
        { }

        public DbSet<City> Cities { get; set; }
        public DbSet<WeatherData> WeatherData { get; set; }
    }
}
