using Portfolio.Api.DTOs;

namespace Portfolio.Api.Data;

public interface IProjectRepository
{
    Task<List<ProjectDto>> GetProjectsAsync();
    Task<ProjectDto?> GetProjectByIdAsync(int projectId);
    Task<ProjectDto> CreateProjectAsync(CreateProjectRequest request);
    Task<ProjectDto?> UpdateProjectAsync(
        int projectId,
        UpdateProjectRequest request);
}