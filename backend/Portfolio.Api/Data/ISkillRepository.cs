using Portfolio.Api.DTOs;

namespace Portfolio.Api.Data;

public interface ISkillRepository
{
    Task<List<SkillDto>> GetSkillsAsync();
}