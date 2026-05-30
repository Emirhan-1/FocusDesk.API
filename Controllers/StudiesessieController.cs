using FocusDesk.API.DTOs;
using FocusDesk.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FocusDesk.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class StudiesessieController : ControllerBase
{
    private readonly StudiesessieService _studiesessieService;

    public StudiesessieController(StudiesessieService studiesessieService)
    {
        _studiesessieService = studiesessieService;
    }

    // GET alle sessies
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var sessies = await _studiesessieService.GetAll();

        return Ok(sessies);
    }

    // GET sessie op ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var sessie = await _studiesessieService.GetById(id);

        if (sessie == null)
        {
            return NotFound();
        }

        return Ok(sessie);
    }

    // POST nieuwe sessie
    [HttpPost]
    public async Task<IActionResult> Create(MaakStudieSessieDTO dto)
    {
        var sessie = await _studiesessieService.Create(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = sessie.Id },
            sessie
        );
    }

    // DELETE sessie
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _studiesessieService.Delete(id);

        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
    int id,
    BewerkStudiesessieDTO dto)
    {
        var sessie = await _studiesessieService
            .Update(id, dto);

        if (sessie == null)
        {
            return NotFound();
        }

        return Ok(sessie);
    }

    [HttpGet("totale-studietijd")]
    public async Task<IActionResult> GetTotaleStudietijd()
    {
        var totaal = await _studiesessieService
            .GetTotaleStudietijd();

        return Ok(new
        {
            totaleStudietijd = totaal
        });
    }
}