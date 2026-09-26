using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.DTOs;
using Portfolio.Api.Services;

namespace Portfolio.Api.Controllers;

[ApiController]
[Route("api/skills")]
public class SkillController : ControllerBase
{
    private readonly ISkillService _skillService;

    public SkillController(ISkillService skillService)
    {
        _skillService = skillService;
    }

    [HttpGet]
    public async Task<ActionResult<List<SkillDto>>> GetSkills()
    {
        var skills = await _skillService.GetSkillsAsync();

        return Ok(skills);
    }
}