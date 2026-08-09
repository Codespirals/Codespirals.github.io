using Codespirals.Solutions.ApiCaller;

namespace Codespirals.HomePage;

public interface IGitHubService
{

}

public class GitHubService : IGitHubService
{
    private ApiCaller _apiCaller;

    public GitHubService(IApiCallerFactory apiCallerFactory)
    {
        _apiCaller = apiCallerFactory.InitializeApiCaller("https://api.github.com/", userAgent: "codespirals");
        _apiCaller.AddDefaultHeader("Accept", "application/vnd.github+json");
        _apiCaller.AddDefaultHeader("Authorization", "Bearer <YOUR-TOKEN>");
        _apiCaller.AddDefaultHeader("X-GitHub-Api-Version", "2026-03-10");
    }


}
