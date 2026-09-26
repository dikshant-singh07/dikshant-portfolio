using Portfolio.Api.DTOs;

namespace Portfolio.Api.Services;

public interface ISkillService
{
    Task<List<SkillDto>> GetSkillsAsync();
}