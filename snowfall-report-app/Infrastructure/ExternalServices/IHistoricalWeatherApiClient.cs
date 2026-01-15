using snowfall_report_app.Domain.Models;

namespace snowfall_report_app.Infrastructure.ExternalServices;

public interface IHistoricalWeatherApiClient
{
    Task<SnowfallResponseModel?> GetHistoricalWeatherDataAsync();
}