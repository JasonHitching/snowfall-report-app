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
    public async Task<ActionResult<SnowfallResponseModel>> GetUpcomingSnowfallAsync()
    {
        var response = await upcomingWeatherApiClient.GetUpcomingWeatherAsync();

        if (response is null) return NotFound();

        return Ok(response);
    }
}