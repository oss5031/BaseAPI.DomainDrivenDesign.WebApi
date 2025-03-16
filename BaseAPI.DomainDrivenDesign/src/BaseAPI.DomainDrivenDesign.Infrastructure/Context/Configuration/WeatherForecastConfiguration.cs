using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseAPI.DomainDrivenDesign.Infrastructure.Context.Configuration
{
	public class WeatherForecastConfiguration : IEntityTypeConfiguration<WeatherForecast>
    {
        public void Configure(EntityTypeBuilder<WeatherForecast> builder)
        {
            // Example of Fluent API configuration
            builder.ToTable("WeatherForecasts");

            builder.HasKey(wf => wf.Id);

            builder.Property(wf => wf.Date)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(wf => wf.TemperatureC)
                .IsRequired();

            builder.Property(wf => wf.Summary)
                .HasMaxLength(200);
        }
    }
}

