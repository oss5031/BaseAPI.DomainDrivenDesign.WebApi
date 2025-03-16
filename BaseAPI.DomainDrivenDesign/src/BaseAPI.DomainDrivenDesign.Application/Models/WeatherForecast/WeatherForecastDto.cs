namespace BaseAPI.DomainDrivenDesign.Application.Models.WeatherForecast
{
	public class WeatherForecastDto
	{
        public int Id { get; init; }

        public DateTime Date { get; init; }

        public int TemperatureC { get; init; }

        public string? Summary { get; init; }
    }
}

