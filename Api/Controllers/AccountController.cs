using Core.Dtos;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController(IAccountService service) : ControllerBase
{
    private readonly IAccountService _service = service;

    [HttpPost("Create")]
    public async Task<IActionResult> Create(AccountRegisterDto accountRegisterDto)
    {
        await _service.Create(accountRegisterDto);

        return Ok("Account created");
    }
    
    
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAll());
    }
    
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _service.GetById(id));
    }
    
    [HttpPut("Update")]
    public async Task<IActionResult> Update(int id, AccountUpdateDto accountDto)
    {
        await _service.Update(id, accountDto);
        return Ok("Account updated");
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return Ok("Account deleted");
    }
}