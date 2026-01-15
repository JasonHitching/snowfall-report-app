using System.Runtime.CompilerServices;
using snowfall_report_app.Infrastructure.ExternalServices;

namespace snowfall_report_app
{
    public class TestApi
    {

        IHistoricalWeatherApiClient historicalWeatherApiClient;

        public TestApi(IHistoricalWeatherApiClient historicalWeatherApiClient)
        {
            this.historicalWeatherApiClient = historicalWeatherApiClient;
        }

        public async Task TestApiCall()
        {
            await historicalWeatherApiClient.GetHistoricalWeatherDataAsync();
        }
    }
}