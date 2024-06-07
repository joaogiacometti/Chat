using Core.Dtos;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController(IMessageService service) : ControllerBase
{
    private readonly IMessageService _service = service;

    [Authorize(Roles = "User, Admin")]
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var list = await _service.GetAll();

            return Ok(list);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize(Roles ="User, Admin")]
    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        try
        {
            var list = await _service.GetById(id);

            return Ok(list);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize(Roles ="User, Admin")]
    [HttpGet("GetByUserId/{id}")]
    public async Task<IActionResult> GetByUserId(string id)
    {
        try
        {
            var list = await _service.GetByUserId(id);

            return Ok(list);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [Authorize(Roles ="User, Admin")]
    [HttpGet("GetByChatId/{id}")]
    public async Task<IActionResult> GetByChatId(string id)
    {
        try
        {
            var list = await _service.GetByChatId(id);

            return Ok(list);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize(Roles ="User, Admin")]
    [HttpPost("Send")]
    public async Task<IActionResult> Send([FromBody] MessageCreateDto messageDto)
    {
        try
        {
            await _service.Send(messageDto);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize(Roles ="User, Admin")]
    [HttpPut("Update")]
    public async Task<IActionResult> Put([FromBody] MessageUpdateDto messageDto)
    {
        try
        {
            await _service.Update(messageDto);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize(Roles ="Admin")]
    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            await _service.Delete(id);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}