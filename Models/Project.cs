namespace RodrigoRoman.Portfolio.Models;

public class Project
{
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string LongDescription { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public ProjectStatus Status { get; set; } = ProjectStatus.Concepto;
    public List<string> Technologies { get; set; } = new();
    public List<string> Features { get; set; } = new();
    public string ProblemSolved { get; set; } = string.Empty;
    public string WhatItDemonstrates { get; set; } = string.Empty;

    /// <summary>
    /// Rutas relativas a wwwroot (ej: "img/projects/gestion-administrativa/panel.png").
    /// Si la lista está vacía se muestra un placeholder.
    /// </summary>
    public List<string> Screenshots { get; set; } = new();

    /// <summary>
    /// URL del repositorio. Si es null se muestra "Repositorio: pendiente de publicación".
    /// </summary>
    public string? RepositoryUrl { get; set; }
}

public enum ProjectStatus
{
    Demo,
    EnDesarrollo,
    Concepto
}

public static class ProjectStatusExtensions
{
    public static string ToDisplay(this ProjectStatus status) => status switch
    {
        ProjectStatus.Demo => "Demo",
        ProjectStatus.EnDesarrollo => "En desarrollo",
        ProjectStatus.Concepto => "Concepto",
        _ => status.ToString()
    };
}
