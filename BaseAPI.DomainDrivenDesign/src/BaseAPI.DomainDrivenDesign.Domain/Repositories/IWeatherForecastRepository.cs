using BaseAPI.DomainDrivenDesign.Domain.Entities.WeatherForecast;

namespace BaseAPI.DomainDrivenDesign.Domain.Repositories
{
	public interface IWeatherForecastRepository
	{
        Task<IEnumerable<GetWeatherForecast>> GetAll(CancellationToken ct);
        Task<GetWeatherForecast?> GetById(int id, CancellationToken ct);
        Task Add(SetWeatherForecast setWeatherForecast, CancellationToken ct);
    }
}

