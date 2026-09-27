namespace Portfolio.Api.DTOs;

public class TechnologyItemDto
{
    public int TechnologyId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public int DisplayOrder { get; set; }
}