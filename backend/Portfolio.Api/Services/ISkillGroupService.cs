using Portfolio.Api.DTOs;

namespace Portfolio.Api.Services;

public interface ISkillGroupService
{
    Task<List<SkillGroupDto>> GetSkillGroupsAsync();
}