using Portfolio.Api.DTOs;

namespace Portfolio.Api.Services;

public interface IProjectService
{
    Task<List<ProjectDto>> GetProjectsAsync();
}