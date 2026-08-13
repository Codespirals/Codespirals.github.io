namespace Codespirals.HomePage.Models.GitHub;

public class Repo
{
    public int Id { get; set; }
    public bool Private { get; set; }
    public string Name { get; set; } = "";
    /// <summary>
    /// Name with org
    /// </summary>
    public string Full_Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string Html_Url { get; set; } = "";
    /// <summary>
    /// >The direct URL for further api calls
    /// </summary>
    public string Url { get; set; } = "";
    public string[] Topics { get; set; } = [];
    public DateTime Pushed_At { get; set; }
}
