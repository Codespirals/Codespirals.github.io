namespace Codespirals.HomePage.Models.GitHub;

public class Repo
{
    public int Id { get; set; }
    public bool Private { get; set; }
    public string Name { get; set; } = "";
    /// <summary>
    /// Name with org
    /// </summary>
    public string FullName { get; set; } = "";
    public string Description { get; set; } = "";
    public string HtmlUrl { get; set; } = "";
    /// <summary>
    /// >The direct URL for further api calls
    /// </summary>
    public string Url { get; set; } = "";
}
