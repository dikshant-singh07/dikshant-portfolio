using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.DTOs;
using Portfolio.Api.Services;

namespace Portfolio.Api.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProjectDto>>> GetProjects()
    {
        var projects = await _projectService.GetProjectsAsync();

        return Ok(projects);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProjectDto>> GetProjectById(int id)
    {
        var project = await _projectService.GetProjectByIdAsync(id);

        if (project is null)
        {
            return NotFound();
        }

        return Ok(project);
    }

    [HttpPost]
    public async Task<ActionResult<ProjectDto>> CreateProject(
        CreateProjectRequest request)
    {
        var project = await _projectService.CreateProjectAsync(request);

        return CreatedAtAction(
            nameof(GetProjectById),
            new { id = project.Id },
            project);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ProjectDto>> UpdateProject(
        int id,
        UpdateProjectRequest request)
    {
        var project = await _projectService.UpdateProjectAsync(
            id,
            request);

        if (project is null)
        {
            return NotFound();
        }

        return Ok(project);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        var deleted = await _projectService.DeleteProjectAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }

}