using Portfolio.Api.DTOs;

namespace Portfolio.Api.Services;

public interface IExperienceService
{
    Task<List<ExperienceDto>> GetExperiencesAsync();
}