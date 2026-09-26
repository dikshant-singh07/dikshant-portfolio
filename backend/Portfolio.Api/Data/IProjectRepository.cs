using Portfolio.Api.DTOs;

namespace Portfolio.Api.Data;

public interface IProjectRepository
{
    Task<List<ProjectDto>> GetProjectsAsync();
}