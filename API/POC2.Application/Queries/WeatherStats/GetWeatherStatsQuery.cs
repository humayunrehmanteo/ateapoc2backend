using MediatR;
using POC2.Application.Dtos;
using System.ComponentModel.DataAnnotations;

namespace POC2.Application.Queries.WeatherStats
{
    public class GetWeatherStatsQuery : IRequest<WeatherStatsResponse>
    {
        [Required]
        public int CityId { get; set; }

    }
}
