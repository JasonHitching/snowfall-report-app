using System.Net.Http.Json;
using System.Text.Json.Serialization;
using snow_report_app.Domain.Models;

namespace snowfall_report_app.Infrastructure.ExternalServices
{
    public class HistoricalWeatherApiClient(HttpClient httpClient) : IHistoricalWeatherApiClient
    {
        private readonly HttpClient _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

        public async Task GetHistoricalWeatherDataAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<HistoricalSnowfallModel>($"v1/archive?latitude=41.8&longitude=23.49&start_date=2025-12-29&end_date=2026-01-12&daily=snowfall_sum");

            if (response is not null && response.Daily is not null && response.Daily.SnowfallSum.Count > 0)
            {
                foreach (var value in response.Daily.SnowfallSum)
                {
                    Console.WriteLine(value);
                }
            }
        }
    }
}