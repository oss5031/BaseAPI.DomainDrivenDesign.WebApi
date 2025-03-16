using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaseAPI.DomainDrivenDesign.Domain.Entities.WeatherForecast;
using BaseAPI.DomainDrivenDesign.Domain.Repositories;
using BaseAPI.DomainDrivenDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;


namespace BaseAPI.DomainDrivenDesign.Infrastructure.Repositories
{
	public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly IDbContextFactory<DbAppContext> contextFactory;
        private readonly IMapper mapper;

        public WeatherForecastRepository(IDbContextFactory<DbAppContext> contextFactory, IMapper mapper)
		{
            this.contextFactory = contextFactory;
            this.mapper = mapper;
		}

        public async Task Add(SetWeatherForecast setWeatherForecast, CancellationToken ct)
        {
            using (var context = contextFactory.CreateDbContext())
            {
                var weatherForecast = mapper.Map<WeatherForecast>(setWeatherForecast);

                await context.WeatherForecast.AddAsync(weatherForecast, ct);

                await context.SaveChangesAsync(ct);
            }
        }

        public async Task<IEnumerable<GetWeatherForecast>> GetAll(CancellationToken ct)
        {
            using (var context = contextFactory.CreateDbContext())
            {
                var result = await context.WeatherForecast
                    .AsNoTracking()
                    .ProjectTo<GetWeatherForecast>(mapper.ConfigurationProvider)
                    .ToListAsync(ct);

                return result;
            }
        }

        public async Task<GetWeatherForecast?> GetById(int id, CancellationToken ct)
        {
            using (var context = contextFactory.CreateDbContext())
            {
                var result = await context.WeatherForecast
                    .AsNoTracking()
                    .ProjectTo<GetWeatherForecast>(mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(wf => wf.Id == id, ct);

                return result;
            }
        }
    }
}

