using BaseAPI.DomainDrivenDesign.Application.Models.WeatherForecast;

namespace BaseAPI.DomainDrivenDesign.Application.Services.Interfaces
{
	public interface IWeatherForecastService
	{
        Task<IEnumerable<WeatherForecastDto>> GetAll(CancellationToken ct);
        Task<WeatherForecastDto> GetById(int id, CancellationToken ct);
        Task Create(CreateWeatherForecastDto createWeatherForecast, CancellationToken ct);
    }
}

