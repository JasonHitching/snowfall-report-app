using System.Text.Json.Serialization;

namespace snowfall_report_app.Domain.Models;

public class SnowfallResponseModel
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double GenerationtimeMs { get; set; }
    public int UtcOffsetSeconds { get; set; }
    public string Timezone { get; set; } = default!;
    public string TimezoneAbbreviation { get; set; } = default!;
    public double Elevation { get; set; }

    [JsonPropertyName("daily_units")]
    public required DailyUnitsDto DailyUnits { get; set; }

    public required DailySnowfallDto Daily { get; set; }
}

public class DailyUnitsDto
{
    [JsonPropertyName("time")]
    public string TimeFormat { get; set; } = default!;

    [JsonPropertyName("snowfall_sum")]
    public string SnowfallUnit { get; set; } = default!;
}

public class DailySnowfallDto
{
    [JsonPropertyName("time")]
    public List<string> Time { get; set; } = default!;

    [JsonPropertyName("snowfall_sum")]
    public List<double> SnowfallSum { get; set; } = default!;

    [JsonPropertyName("snow_depth_max")]
    public List<double> SnowfallDepthMax { get; set; } = default!;
} 