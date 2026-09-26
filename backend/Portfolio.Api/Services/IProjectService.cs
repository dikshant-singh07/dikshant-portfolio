using Portfolio.Api.DTOs;

namespace Portfolio.Api.Services;

public interface IProjectService
{
    Task<List<ProjectDto>> GetProjectsAsync();
    Task<ProjectDto?> GetProjectByIdAsync(int projectId);
    Task<ProjectDto> CreateProjectAsync(CreateProjectRequest request);
    Task<ProjectDto?> UpdateProjectAsync(
        int projectId,
        UpdateProjectRequest request);
    Task<bool> DeleteProjectAsync(int projectId);
}