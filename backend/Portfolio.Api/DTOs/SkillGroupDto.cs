namespace Portfolio.Api.DTOs;

public class SkillGroupDto
{
    public int SkillGroupId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string GroupType { get; set; } = string.Empty;
    public int DisplayOrder { get; set; }

    public List<SkillItemDto> Skills { get; set; } = new();
    public List<TechnologyItemDto> Technologies { get; set; } = new();
}