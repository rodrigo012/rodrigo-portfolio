namespace RodrigoRoman.Portfolio.Models;

public class Skill
{
    public string Name { get; set; } = string.Empty;

    public Skill() { }
    public Skill(string name) => Name = name;
}
