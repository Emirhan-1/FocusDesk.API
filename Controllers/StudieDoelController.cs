using FocusDesk.API.DTOs;
using FocusDesk.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FocusDesk.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class StudieDoelController : ControllerBase
{
    private readonly StudieDoelService _studieDoelService;

    public StudieDoelController(
        StudieDoelService studieDoelService)
    {
        _studieDoelService = studieDoelService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var doelen = await _studieDoelService.GetAll();

        return Ok(doelen);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var doel = await _studieDoelService.GetById(id);

        if (doel == null)
        {
            return NotFound();
        }

        return Ok(doel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        MaakStudieDoelDTO dto)
    {
        var doel = await _studieDoelService
            .Create(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = doel.Id },
            doel
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _studieDoelService
            .Delete(id);

        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }
}