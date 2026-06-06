using FocusDesk.API.DTOs;
using FocusDesk.API.Models;
using FocusDesk.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FocusDesk.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class StudieDoelController : ControllerBase
{
    private readonly StudieDoelService _service;

    public StudieDoelController(StudieDoelService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var doelen = await _service.GetAll();
        var result = doelen.Select(d => new
        {
            d.Id,
            d.Titel,
            d.DoelUren,
            d.BestedeUren,
            VoortgangPercentage = _service.BerekenPercentage(d)
        });
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var doel = await _service.GetById(id);
        if (doel == null) return NotFound();

        return Ok(new
        {
            doel.Id,
            doel.Titel,
            doel.DoelUren,
            doel.BestedeUren,
            VoortgangPercentage = _service.BerekenPercentage(doel)
        });
    }

    [HttpPost]
    public async Task<ActionResult> Create(MaakStudieDoelDTO dto)
    {
        var doel = await _service.Create(dto);
        return CreatedAtAction(
            nameof(GetById),
            new { id = doel.Id },
            new
            {
                doel.Id,
                doel.Titel,
                doel.DoelUren,
                doel.BestedeUren,
                VoortgangPercentage = 0
            });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, BewerkStudieDoelDTO dto)
    {
        var doel = await _service.Update(id, dto);
        if (doel == null) return NotFound();

        return Ok(new
        {
            doel.Id,
            doel.Titel,
            doel.DoelUren,
            doel.BestedeUren,
            VoortgangPercentage = _service.BerekenPercentage(doel)
        });
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var success = await _service.Delete(id);
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpPatch("{id}/uren")]
    public async Task<IActionResult> VoegUrenToe(int id, [FromBody] int uren)
    {
        var doel = await _service.VoegUrenToe(id, uren);
        if (doel == null) return NotFound();

        var percentage = _service.BerekenPercentage(doel);
        return Ok(new
        {
            doel.Id,
            doel.Titel,
            doel.DoelUren,
            doel.BestedeUren,
            VoortgangPercentage = percentage
        });
    }
}