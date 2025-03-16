using AutoMapper;
using BaseAPI.DomainDrivenDesign.Application.Models.WeatherForecast;
using BaseAPI.DomainDrivenDesign.WebApi.Models;
using BaseAPI.DomainDrivenDesign.WebApi.Models.WeatherForecast;

namespace BaseAPI.DomainDrivenDesign.WebApi.Mapping.WeatherForecast
{
    public class WeatherForecastProfile : Profile
	{
		public WeatherForecastProfile()
		{
			CreateMap<WeatherForecastDto, GetWeatherForecastResponseModel>();
			CreateMap<PostWeatherForecastRequestModel, CreateWeatherForecastDto>();
        }
	}
}

