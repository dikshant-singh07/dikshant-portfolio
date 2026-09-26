using Portfolio.Api.Data;
using Portfolio.Api.DTOs;

namespace Portfolio.Api.Services;

public class SkillService : ISkillService
{
    private readonly ISkillRepository _skillRepository;

    public SkillService(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    public async Task<List<SkillDto>> GetSkillsAsync()
    {
        return await _skillRepository.GetSkillsAsync();
    }
}