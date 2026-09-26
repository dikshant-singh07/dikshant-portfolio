using Portfolio.Api.Data;
using Portfolio.Api.DTOs;

namespace Portfolio.Api.Services;

public class ExperienceService : IExperienceService
{
    private readonly IExperienceRepository _experienceRepository;

    public ExperienceService(IExperienceRepository experienceRepository)
    {
        _experienceRepository = experienceRepository;
    }

    public async Task<List<ExperienceDto>> GetExperiencesAsync()
    {
        return await _experienceRepository.GetExperiencesAsync();
    }
}