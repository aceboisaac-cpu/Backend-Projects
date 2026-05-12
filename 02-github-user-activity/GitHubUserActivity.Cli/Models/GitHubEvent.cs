using System.Text.Json.Serialization;

namespace GitHubUserActivity.Cli.Models;

public class GitHubEvent
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("repo")]
    public RepoInfo Repo { get; set; } = new();

    [JsonPropertyName("payload")]
    public EventPayload Payload { get; set; } = new();
}

public class RepoInfo
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}
