using System.Globalization;
using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using snowfall_report_app.Infrastructure.ExternalServices;

namespace snowfall_report_app;

class Program
{
    public record HistoricalReadings(DateTime Date, double Value);

    public record UpcomingReadings(DateTime Date, double Value);

    static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                // HttpClientFactory
                services.AddHttpClient<IHistoricalWeatherApiClient, HistoricalWeatherApiClient>(historicalClient =>
                {
                    historicalClient.BaseAddress = new Uri("https://archive-api.open-meteo.com/");
                });

                services.AddHttpClient<IUpcomingWeatherApiClient, UpcomingWeatherApiClient> ( upcomingClient =>
                {
                    upcomingClient.BaseAddress = new Uri("https://api.open-meteo.com/");
                });

                services.AddTransient<TestApi>();
            })
            .Build();

        // Resolve and use TestApi
        var testApi = host.Services.GetRequiredService<TestApi>();

        var historicalResponse = await testApi.TestHistoricalFetch();

        var historicalReadings = historicalResponse!.Daily.Time
            .Zip(historicalResponse.Daily.SnowfallSum,
                (time, snowfall) =>
                {
                    if (!DateTime.TryParseExact(time, "yyyy-MM-dd",     
                                                CultureInfo.InvariantCulture, 
                                                DateTimeStyles.None, out DateTime result))
                    {
                        throw new FormatException($"Invalid date format: {time}");
                    }
                    
                    return new HistoricalReadings(result, snowfall);
                });

        var upcomingResponse = await testApi.TestUpcomingHistoricalFetch();

        var upcomingReadings = upcomingResponse!.Daily.Time
            .Zip(upcomingResponse.Daily.SnowfallSum,
                (time, snowfall) => 
                {
                    if (!DateTime.TryParseExact(time, "yyyy-MM-dd", CultureInfo.InvariantCulture, 
                                                DateTimeStyles.None, out DateTime result))
                    {
                        throw new FormatException($"Invalid date format: {time}");
                    }
                    
                    return new UpcomingReadings(DateTime.Parse(time), snowfall);
                }); 
    }
}
