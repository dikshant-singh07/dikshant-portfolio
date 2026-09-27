using Portfolio.Api.Data;
using Portfolio.Api.DTOs;

namespace Portfolio.Api.Services;

public class SkillGroupService : ISkillGroupService
{
    private readonly ISkillGroupRepository _repository;

    public SkillGroupService(ISkillGroupRepository repository)
    {
        _repository = repository;
    }

    public Task<List<SkillGroupDto>> GetSkillGroupsAsync()
    {
        return _repository.GetSkillGroupsAsync();
    }
}