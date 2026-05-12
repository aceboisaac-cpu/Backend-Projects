using GitHubUserActivity.Cli.Models;

namespace GitHubUserActivity.Cli.Formatting;

public static class ActivityFormatter
{
    public static string Format(GitHubEvent ev)
    {
        return ev.Type switch
        {
            "PushEvent" => $"- Pushed {ev.Payload.Commits?.Count ?? 0} commits to {ev.Repo.Name}",
            "IssuesEvent" => $"- Opened/updated an issue in {ev.Repo.Name}",
            "WatchEvent" => $"- Starred {ev.Repo.Name}",
            "ForkEvent" => $"- Forked {ev.Repo.Name}",
            _ => $"- {ev.Type} in {ev.Repo.Name}"
        };
    }
}
