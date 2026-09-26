using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.DTOs;
using Portfolio.Api.Services;

namespace Portfolio.Api.Controllers;

[ApiController]
[Route("api/technologies")]
public class TechnologyController : ControllerBase
{
    private readonly ITechnologyService _technologyService;

    public TechnologyController(ITechnologyService technologyService)
    {
        _technologyService = technologyService;
    }

    [HttpGet]
    public async Task<ActionResult<List<TechnologyDto>>> GetTechnologies()
    {
        var technologies = await _technologyService.GetTechnologiesAsync();

        return Ok(technologies);
    }
}