using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SecondTaskWeather.Infrastructure
{
    internal class WeatherContextFactory : IDesignTimeDbContextFactory<WeatherDBContext>
    {
        public WeatherDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WeatherDBContext>();
            optionsBuilder.UseSqlServer(FuncConfigurations.DBConnectionString.Value);

            return new WeatherDBContext(optionsBuilder.Options);
        }
    }
}
