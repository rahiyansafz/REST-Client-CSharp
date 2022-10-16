using System.Net.Http.Headers;
using System.Text.Json;
using WebAPIClient.Models;

namespace WebAPIClient;

public static class App
{
    private static readonly HttpClient client = new();

    public static async Task Run()
    {
        var repositories = await ProcessRepositories();

        foreach (var repo in repositories)
        {
            Console.WriteLine(repo.Name);
            Console.WriteLine(repo.Description);
            Console.WriteLine(repo.GitHubHomeUrl);
            Console.WriteLine(repo.Homepage);
            Console.WriteLine(repo.Watchers);
            Console.WriteLine(repo.LastPush);
            Console.WriteLine();
        }
    }

    static async Task<List<Repository>> ProcessRepositories()
    {

        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

        var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
        var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);

        return repositories;
    }
}