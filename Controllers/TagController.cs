using FocusDesk.API.DTOs;
using FocusDesk.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FocusDesk.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TagController : ControllerBase
{
    private readonly TagService _service;

    public TagController(TagService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var tags = await _service.GetAll();
        return Ok(tags);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var tag = await _service.GetById(id);
        if (tag == null) return NotFound();
        return Ok(tag);
    }

    [HttpPost]
    public async Task<ActionResult> Create(MaakTagDTO dto)
    {
        var tag = await _service.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = tag.Id }, tag);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, MaakTagDTO dto)
    {
        var tag = await _service.Update(id, dto);
        if (tag == null) return NotFound();
        return Ok(tag);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var success = await _service.Delete(id);
        if (!success) return NotFound();
        return NoContent();
    }
}