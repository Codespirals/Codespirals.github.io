using Codespirals.HomePage.Models.GitHub;
using Codespirals.Solutions.ApiCaller;

namespace Codespirals.HomePage;

public interface IGitHubService
{
    public Task<IEnumerable<Repo>> GetLibraries();
    public Task<IEnumerable<Repo>> GetSolutions();
}

public class GitHubService : IGitHubService
{
    private ApiCaller _apiCaller;

    public GitHubService(IApiCallerFactory apiCallerFactory)
    {
        _apiCaller = apiCallerFactory.CreateApiCaller("https://api.github.com/", group: "", userAgent: "codespirals");
        _apiCaller.AddDefaultHeader("Accept", "application/vnd.github+json");
        _apiCaller.AddDefaultHeader("X-GitHub-Api-Version", "2026-03-10");
    }

    private async Task<IEnumerable<Repo>> GetRepositories()
    {
        var result = await _apiCaller.Get<IEnumerable<Repo>>("orgs/Codespirals", "repos");
        if (!result.Success)
            return [];
        return result.Data!.OrderByDescending(l => l.Pushed_At);
    }

    public async Task<IEnumerable<Repo>> GetLibraries()
         => (await GetRepositories()).Where(r => r.Topics.Contains("library"));
    public async Task<IEnumerable<Repo>> GetSolutions()
         => (await GetRepositories()).Where(r => r.Topics.Contains("solution"));
}
