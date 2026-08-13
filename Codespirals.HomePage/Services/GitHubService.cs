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
        _apiCaller.AddDefaultHeader("Authorization", $"Bearer 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");
        _apiCaller.AddDefaultHeader("X-GitHub-Api-Version", "2026-03-10");
    }

    private async Task<ApiResult<IEnumerable<Repo>>> GetRepositories()
        => await _apiCaller.Get<IEnumerable<Repo>>("orgs/Codespirals", "repos");

    public async Task<IEnumerable<Repo>> GetLibraries()
    {
        var result = await GetRepositories();
        if (!result.Success)
            return [];
        return result.Data!.Where(r => r.Topics.Contains("library"));
    }
    public async Task<IEnumerable<Repo>> GetSolutions()
    {
        var result = await GetRepositories();
        if (!result.Success)
            return [];
        return result.Data!.Where(r => r.Topics.Contains("solution"));
    }
}
