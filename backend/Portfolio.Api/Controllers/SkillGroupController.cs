using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.DTOs;
using Portfolio.Api.Services;

namespace Portfolio.Api.Controllers;

[ApiController]
[Route("api/skill-groups")]
public class SkillGroupController : ControllerBase
{
    private readonly ISkillGroupService _service;

    public SkillGroupController(ISkillGroupService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<SkillGroupDto>>> GetSkillGroups()
    {
        var groups = await _service.GetSkillGroupsAsync();

        return Ok(groups);
    }
}