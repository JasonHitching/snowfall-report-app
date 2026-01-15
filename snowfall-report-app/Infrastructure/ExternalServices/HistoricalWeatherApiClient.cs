namespace snowfall_report_app.Infrastructure.ExternalServices
{
    public class HistoricalWeatherApiClient(HttpClient httpClient) : IHistoricalWeatherApiClient
    {
        private readonly HttpClient _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

        public async Task<string> GetHistoricalWeatherDataAsync(string location, DateTime date)
        {
            var response = await _httpClient.GetAsync($"endpoint?location={location}&date={date:yyyy-MM-dd}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}