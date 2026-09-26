using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.DTOs;
using Portfolio.Api.Services;

namespace Portfolio.Api.Controllers;

[ApiController]
[Route("api/contact")]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateContactMessage(
        CreateContactMessageRequest request)
    {
        await _contactService.CreateContactMessageAsync(request);

        return Ok(new
        {
            message = "Your message has been submitted successfully."
        });
    }
}