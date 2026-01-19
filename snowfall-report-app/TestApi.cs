using System.Runtime.CompilerServices;
using snowfall_report_app.Domain.Models;
using snowfall_report_app.Infrastructure.ExternalServices;

namespace snowfall_report_app
{
    public class TestApi(IHistoricalWeatherApiClient historicalWeatherApiClient, IUpcomingWeatherApiClient upcomingWeatherApiClient)
    {
        readonly IHistoricalWeatherApiClient historicalWeatherApiClient = historicalWeatherApiClient;
        readonly IUpcomingWeatherApiClient upcomingWeatherApiClient = upcomingWeatherApiClient;

        public async Task<SnowfallResponseModel?> TestHistoricalFetch()
        {
            var response = await historicalWeatherApiClient.GetHistoricalWeatherDataAsync();

            return response;
        }

        public async Task<SnowfallResponseModel?> TestUpcomingHistoricalFetch()
        {
            var response = await upcomingWeatherApiClient.GetUpcoming16DaySnowfallAsync();

            return response;
        }
    }
}