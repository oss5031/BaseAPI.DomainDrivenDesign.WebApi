namespace BaseAPI.DomainDrivenDesign.Application.Models.WeatherForecast
{
	public class CreateWeatherForecastDto
	{
        public DateTime Date { get; init; }

        public int TemperatureC { get; init; }

        public string? Summary { get; init; }
    }
}

