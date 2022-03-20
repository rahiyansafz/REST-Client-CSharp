using System.Globalization;
using System.Text.Json.Serialization;

namespace WebAPIClient.Models;

public class Repository
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("description")]
    public string Description { get; set; } = null!;

    [JsonPropertyName("html_url")]
    public Uri GitHubHomeUrl { get; set; } = null!;

    [JsonPropertyName("homepage")]
    public Uri Homepage { get; set; } = null!;

    [JsonPropertyName("watchers")]
    public int Watchers { get; set; }

    [JsonPropertyName("pushed_at")]
    public string JsonDate { get; set; } = null!;

    public DateTime LastPush =>
        DateTime.ParseExact(JsonDate, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
}
