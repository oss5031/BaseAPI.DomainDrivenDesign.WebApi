namespace BaseAPI.DomainDrivenDesign.WebApi.Models.WeatherForecast
{
	public class GetWeatherForecastResponseModel
	{
        public int Id { get; init; }

        public DateTime Date { get; init; }

        public int TemperatureC { get; init; }

        public string? Summary { get; init; }
    }
}

