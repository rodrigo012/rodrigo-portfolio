namespace RodrigoRoman.Portfolio.Models;

public class SkillCategory
{
    public string Name { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public List<Skill> Skills { get; set; } = new();
}
