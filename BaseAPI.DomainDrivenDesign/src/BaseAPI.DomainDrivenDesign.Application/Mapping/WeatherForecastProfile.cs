using AutoMapper;
using BaseAPI.DomainDrivenDesign.Application.Models.WeatherForecast;
using BaseAPI.DomainDrivenDesign.Domain.Entities.WeatherForecast;

namespace BaseAPI.DomainDrivenDesign.Application.Mapping
{
    public class WeatherForecastProfile : Profile
	{
		public WeatherForecastProfile()
		{
            CreateMap<GetWeatherForecast, WeatherForecastDto>();
			CreateMap<CreateWeatherForecastDto, SetWeatherForecast>();
        }
	}
}

