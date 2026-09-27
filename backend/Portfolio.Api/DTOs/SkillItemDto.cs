namespace Portfolio.Api.DTOs;

public class SkillItemDto
{
    public int SkillId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public int DisplayOrder { get; set; }
}