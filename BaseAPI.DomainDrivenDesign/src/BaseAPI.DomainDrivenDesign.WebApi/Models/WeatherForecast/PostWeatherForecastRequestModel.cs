namespace BaseAPI.DomainDrivenDesign.WebApi.Models.WeatherForecast
{
	public class PostWeatherForecastRequestModel
	{
        public DateTime Date { get; init; }
        public int TemperatureC { get; init; }
        public string? Summary { get; init; }
    }
}

