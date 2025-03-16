namespace BaseAPI.DomainDrivenDesign.Domain.Entities.WeatherForecast
{
	public class SetWeatherForecast
    {
        public DateTime Date { get; init; }

        public int TemperatureC { get; init; }

        public string? Summary { get; init; }
    }
}

