using System.Net.Http.Json;
using snowfall_report_app.Domain.Models;

namespace snowfall_report_app.Infrastructure.ExternalServices;

public class UpcomingWeatherApiClient(HttpClient httpClient) : IUpcomingWeatherApiClient
{
    private readonly HttpClient _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

    public async Task<SnowfallResponseModel?> GetUpcoming16DaySnowfallAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<SnowfallResponseModel>("v1/forecast?latitude=41.8383&longitude=23.4885&daily=snowfall_sum,snow_depth_max&forecast_days=16");
        return response;
    }
}