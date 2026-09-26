using Portfolio.Api.Data;
using Portfolio.Api.DTOs;

namespace Portfolio.Api.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<List<ProjectDto>> GetProjectsAsync()
    {
        return await _projectRepository.GetProjectsAsync();
    }

    public async Task<ProjectDto?> GetProjectByIdAsync(int projectId)
    {
        return await _projectRepository.GetProjectByIdAsync(projectId);
    }

    public async Task<ProjectDto> CreateProjectAsync(CreateProjectRequest request)
    {
        return await _projectRepository.CreateProjectAsync(request);
    }

    public async Task<ProjectDto?> UpdateProjectAsync(
        int projectId,
        UpdateProjectRequest request)
    {
        return await _projectRepository.UpdateProjectAsync(
            projectId,
            request);
    }

    public async Task<bool> DeleteProjectAsync(int projectId)
    {
        return await _projectRepository.DeleteProjectAsync(projectId);
    }

}