using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POC2.Domain.Interfaces;
using POC2.Infrastructure.Data;
using POC2.Infrastructure.Repositries;

namespace POC2.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<WeatherDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(WeatherDbContext).Assembly.FullName)));

            services.AddScoped<IWeatherRepository, WeatherDataRepository>();
        }
    }
}
