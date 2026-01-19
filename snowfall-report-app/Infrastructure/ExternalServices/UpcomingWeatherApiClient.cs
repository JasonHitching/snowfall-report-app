using System.Net.Http.Json;
using snowfall_report_app.Domain.Models;

namespace snowfall_report_app.Infrastructure.ExternalServices;

public class UpcomingWeatherApiClient(HttpClient httpClient) : IUpcomingWeatherApiClient
{
    private readonly HttpClient _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

    // <inheritdoc />
    public async Task<SnowfallResponseModel?> GetUpcoming16DaySnowfallAsync(double latitude, double longitude)
    {
        try 
        {
            var response = await _httpClient.GetFromJsonAsync<SnowfallResponseModel>($"v1/forecast?latitude={latitude}&longitude={longitude}&daily=snowfall_sum,snow_depth_max&forecast_days=16");
            
            return response;
        }
        catch (OperationCanceledException cancelledEx) 
        {
            Console.WriteLine($"{cancelledEx}");
            return null;
        }
        catch (Exception ex) 
        {
            Console.WriteLine("Exception thrown whilst fetching data", ex);
            return null;
        }
    }
}