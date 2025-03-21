using BaseAPI.DomainDrivenDesign.WebApi.Models.WeatherForecast;
using FluentValidation;

namespace BaseAPI.DomainDrivenDesign.WebApi.Validators.WeatherForecast
{
	public class PostWeatherForecastValidator : AbstractValidator<PostWeatherForecastRequestModel>
    {
        public PostWeatherForecastValidator()
        {
            RuleFor(x => x.Date)
                .Must(d => d != default)
                .WithMessage("Date is required.");

            RuleFor(x => x.TemperatureC)
                .InclusiveBetween(-70, 70)
                .WithMessage("Temperature must be between -70 and 70 degrees.");

            RuleFor(x => x.Summary)
                .Must(ContainSpecificWords)
                .When(x => !string.IsNullOrWhiteSpace(x.Summary))
                .WithMessage("Summary must contain at least one of the following words: 'A', 'B', or 'C'.");
        }

        private bool ContainSpecificWords(string? summary)
        {
            string[] requiredWords = { "A", "B", "C" };
            return summary != null && requiredWords.Any(word => summary.Contains(word, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}

