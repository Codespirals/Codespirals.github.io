using Codespirals.HomePage.Models.GitHub;
using Codespirals.Solutions.ApiCaller;

namespace Codespirals.HomePage;

public interface IGitHubService
{
    public Task<ApiResult<IEnumerable<Repo>>> GetRepositories();
}

public class GitHubService : IGitHubService
{
    private ApiCaller _apiCaller;

    public GitHubService(IApiCallerFactory apiCallerFactory)
    {
        _apiCaller = apiCallerFactory.CreateApiCaller("https://api.github.com/", userAgent: "codespirals");
        _apiCaller.AddDefaultHeader("Accept", "application/vnd.github+json");
        _apiCaller.AddDefaultHeader("Authorization", $"Bearer {Environment.GetEnvironmentVariable("CODESPIRALS-HOMEPAGE-READ")}");
        _apiCaller.AddDefaultHeader("X-GitHub-Api-Version", "2026-03-10");
    }

    public async Task<ApiResult<IEnumerable<Repo>>> GetRepositories()
        => await _apiCaller.Get<IEnumerable<Repo>>("orgs/Codespirals/repos");
}
