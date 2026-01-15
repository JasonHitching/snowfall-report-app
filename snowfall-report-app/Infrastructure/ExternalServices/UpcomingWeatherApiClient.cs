using System.Net.Http.Json;
using snowfall_report_app.Domain.Models;

namespace snowfall_report_app.Infrastructure.ExternalServices;

public class UpcomingWeatherApiClient(HttpClient httpClient) : IUpcomingWeatherApiClient
{
    private readonly HttpClient _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

    public async Task<SnowfallResponseModel?> GetUpcomingWeatherAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<SnowfallResponseModel>("v1/forecast?latitude=41.8&longitude=23.49&daily=snowfall_sum");
    
        return response;
    }
}