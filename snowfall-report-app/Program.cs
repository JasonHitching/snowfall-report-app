using snowfall_report_app.Infrastructure.ExternalServices;

namespace snowfall_report_app;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddHttpClient<IHistoricalWeatherApiClient, HistoricalWeatherApiClient>(client =>
        {
            client.BaseAddress = new Uri("https://archive-api.open-meteo.com/");
        });

        builder.Services.AddHttpClient<IUpcomingWeatherApiClient, UpcomingWeatherApiClient> ( upcomingClient =>
        {
            upcomingClient.BaseAddress = new Uri("https://api.open-meteo.com/");
        });

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        // builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.MapControllers();

        app.Run();
    }
}
