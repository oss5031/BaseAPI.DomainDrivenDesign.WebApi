using AutoMapper;
using BaseAPI.DomainDrivenDesign.Application.Models.WeatherForecast;
using BaseAPI.DomainDrivenDesign.Application.Services.Interfaces;
using BaseAPI.DomainDrivenDesign.Domain.Entities.WeatherForecast;
using BaseAPI.DomainDrivenDesign.Domain.Repositories;

namespace BaseAPI.DomainDrivenDesign.Application.Services
{
	public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository weatherForecastRepository;
        private readonly IMapper mapper;

        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository, IMapper mapper)
        {
            this.weatherForecastRepository = weatherForecastRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<WeatherForecastDto>> GetAll(CancellationToken ct)
        {
            var getWeatherForescasts = await weatherForecastRepository.GetAll(ct);

            return mapper.Map<IEnumerable<WeatherForecastDto>>(getWeatherForescasts);
        }

        public async Task<WeatherForecastDto> GetById(int id, CancellationToken ct)
        {
            var getWeatherForescast = await weatherForecastRepository.GetById(id, ct);

            return mapper.Map<WeatherForecastDto>(getWeatherForescast);
        }

        public async Task Create(CreateWeatherForecastDto createWeatherForecast, CancellationToken ct)
        {
            var setWeatherForecast = mapper.Map<SetWeatherForecast>(createWeatherForecast);

            await weatherForecastRepository.Add(setWeatherForecast, ct);
        }
    }
}

