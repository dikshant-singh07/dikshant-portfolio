using Portfolio.Api.DTOs;

namespace Portfolio.Api.Data;

public interface ISkillGroupRepository
{
    Task<List<SkillGroupDto>> GetSkillGroupsAsync();
}