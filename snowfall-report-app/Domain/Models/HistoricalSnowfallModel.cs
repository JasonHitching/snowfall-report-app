using System.Text.Json.Serialization;

namespace snow_report_app.Domain.Models;

public class HistoricalSnowfallModel
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double GenerationtimeMs { get; set; }
    public int UtcOffsetSeconds { get; set; }
    public string Timezone { get; set; } = default!;
    public string TimezoneAbbreviation { get; set; } = default!;
    public double Elevation { get; set; }

    public DailyUnitsDto DailyUnits { get; set; }

    public DailySnowfallDto Daily { get; set; }
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
} 