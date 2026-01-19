using snowfall_report_app.Domain.Models;

namespace snowfall_report_app.Infrastructure.ExternalServices;

public interface IUpcomingWeatherApiClient
{
    /// <summary>
    /// Gets the upcoming 16-day snowfall forecast for the specified location.
    /// </summary>
    /// <param name="longitude">The longitude coordinate of the location.</param>
    /// <param name="latitude">The latitude coordinate of the location.</param>
    /// <returns>A task representing the asynchronous operation, containing the snowfall response model or null if unavailable.</returns>
    Task<SnowfallResponseModel?> GetUpcoming16DaySnowfallAsync(double latitude, double longitude);
}
