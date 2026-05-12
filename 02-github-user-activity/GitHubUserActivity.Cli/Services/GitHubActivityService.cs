using System.Net;
using System.Text.Json;
using GitHubUserActivity.Cli.Models;

namespace GitHubUserActivity.Cli.Services;

public class GitHubActivityService
{
    private readonly HttpClient _httpClient;

    public GitHubActivityService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("GitHubUserActivityCli");
    }

    public async Task<List<GitHubEvent>> GetUserEventsAsync(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("El username no puede estar vacío.");

        var url = $"https://api.github.com/users/{username}/events";
        var response = await _httpClient.GetAsync(url);

        if (response.StatusCode == HttpStatusCode.NotFound)
            throw new Exception($"El usuario '{username}' no existe en GitHub.");

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Error consultando GitHub API: {(int)response.StatusCode} {response.ReasonPhrase}");

        var json = await response.Content.ReadAsStringAsync();

        var events = JsonSerializer.Deserialize<List<GitHubEvent>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return events ?? new List<GitHubEvent>();
    }
}
