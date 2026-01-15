using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using snowfall_report_app.Infrastructure.ExternalServices;

namespace snowfall_report_app;

class Program
{
    static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                // HttpClientFactory
                services.AddHttpClient<IHistoricalWeatherApiClient, HistoricalWeatherApiClient>(client =>
                {
                    client.BaseAddress = new Uri("https://archive-api.open-meteo.com/v1/archive?");
                });
            })
            .Build();
            
       /* using var client = new HttpClient();

        var upcomingForecastResponse = await client.GetAsync("https://api.open-meteo.com/v1/forecast?latitude=41.8&longitude=23.49&daily=snowfall_sum");
        upcomingForecastResponse.EnsureSuccessStatusCode();
        
        var data =  await upcomingForecastResponse.Content.ReadAsStringAsync();

        Console.WriteLine(data);

        var historicalEndpoint = "https://archive-api.open-meteo.com/v1/archive?latitude=41.8&longitude=23.49&start_date=2025-12-29&end_date=2026-01-12&daily=snowfall_sum";

        var historicalSnowfallResponse = await client.GetAsync(historicalEndpoint);
        historicalSnowfallResponse.EnsureSuccessStatusCode();

        var historicalSnowfallData = await historicalSnowfallResponse.Content.ReadAsStringAsync(); */

    }
}
