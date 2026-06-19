using FocusDesk.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FocusDesk.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Coach")]
public class CoachController : ControllerBase
{
    private readonly CoachService _service;

    public CoachController(CoachService service)
    {
        _service = service;
    }

    [HttpGet("studenten")]
    public async Task<ActionResult> GetAlleStudenten()
    {
        var studenten = await _service.GetAlleStudenten();
        return Ok(studenten);
    }
}