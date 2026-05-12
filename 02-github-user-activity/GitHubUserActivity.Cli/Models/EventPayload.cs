using System.Text.Json.Serialization;

namespace GitHubUserActivity.Cli.Models;

public class EventPayload
{
    [JsonPropertyName("commits")]
    public List<CommitInfo>? Commits { get; set; }
}

public class CommitInfo
{
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;
}
