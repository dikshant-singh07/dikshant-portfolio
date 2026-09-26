namespace Portfolio.Api.DTOs;

public class CreateProjectRequest
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string? GithubUrl { get; set; }

    public string? LiveUrl { get; set; }
}