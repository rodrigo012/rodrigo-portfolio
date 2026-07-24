namespace RodrigoRoman.Portfolio.Models;

/// <summary>
/// Datos personales del portfolio. Editar los placeholders en PortfolioDataService.
/// </summary>
public class SiteInfo
{
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Tagline { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string GitHubUrl { get; set; } = string.Empty;
    public string LinkedInUrl { get; set; } = string.Empty;
}
