using AutoMapper;
using BaseAPI.DomainDrivenDesign.Domain.Entities.WeatherForecast;

namespace BaseAPI.DomainDrivenDesign.Infrastructure.Mapping.WeatherForecast
{
    public class WeatherForecastProfile : Profile
    {
        public WeatherForecastProfile()
        {
            CreateMap<Context.WeatherForecast, GetWeatherForecast>();
            CreateMap<SetWeatherForecast, Context.WeatherForecast>();
        }
    }
}

