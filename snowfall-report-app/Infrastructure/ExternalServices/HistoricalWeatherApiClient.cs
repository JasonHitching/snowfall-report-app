using System.Net.Http.Json;
using snowfall_report_app.Domain.Models;

namespace snowfall_report_app.Infrastructure.ExternalServices;

public class HistoricalWeatherApiClient(HttpClient httpClient) : IHistoricalWeatherApiClient
{
    private readonly HttpClient _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

    public async Task<SnowfallResponseModel?> GetHistoricalWeatherDataAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<SnowfallResponseModel>($"v1/archive?latitude=41.8&longitude=23.49&start_date=2025-12-29&end_date=2026-01-12&daily=snowfall_sum");

        return response;
    }
}