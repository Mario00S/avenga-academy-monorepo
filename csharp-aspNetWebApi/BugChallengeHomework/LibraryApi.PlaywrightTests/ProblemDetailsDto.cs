using System.Text.Json.Serialization;

namespace LibraryApi.PlaywrightTests;

public class ProblemDetailsDto
{
    public string? Type { get; set; }
    public string? Title { get; set; }
    public int? Status { get; set; }
    public string? Detail { get; set; }

    [JsonPropertyName("errors")]
    public Dictionary<string, string[]>? Errors { get; set; }
}
