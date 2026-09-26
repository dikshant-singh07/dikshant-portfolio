using Portfolio.Api.DTOs;

namespace Portfolio.Api.Data;

public interface IExperienceRepository
{
    Task<List<ExperienceDto>> GetExperiencesAsync();
}