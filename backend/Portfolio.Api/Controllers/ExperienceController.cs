using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.DTOs;
using Portfolio.Api.Services;

namespace Portfolio.Api.Controllers;

[ApiController]
[Route("api/experience")]
public class ExperienceController : ControllerBase
{
    private readonly IExperienceService _experienceService;

    public ExperienceController(IExperienceService experienceService)
    {
        _experienceService = experienceService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ExperienceDto>>> GetExperiences()
    {
        var experiences = await _experienceService.GetExperiencesAsync();

        return Ok(experiences);
    }
}