using Microsoft.AspNetCore.Mvc;
using snowfall_report_app.Domain.Models;
using snowfall_report_app.Infrastructure.ExternalServices;

namespace snowfall_report_app.Infrastructure;

[ApiController]
[Route("api/snowfall")]
public class SnowfallController(IUpcomingWeatherApiClient upcomingWeatherApiClient) : ControllerBase
{
    private readonly IUpcomingWeatherApiClient upcomingWeatherApiClient = upcomingWeatherApiClient;

    [HttpGet("upcoming")]
    public async Task<ActionResult<SnowfallResponseModel>> GetUpcomingSnowfallAsync(
        [FromQuery] double latitude, [FromQuery] double longitude)
    {
        var response = await upcomingWeatherApiClient.GetUpcoming16DaySnowfallAsync(latitude: latitude, longitude: longitude);

        if (response is null) return NotFound();

        return Ok(response);
    }
}