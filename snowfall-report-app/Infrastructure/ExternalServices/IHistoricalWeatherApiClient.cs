namespace snowfall_report_app.Infrastructure.ExternalServices;

public interface IHistoricalWeatherApiClient
{
    Task<string> GetHistoricalWeatherDataAsync(string location, DateTime date);
}