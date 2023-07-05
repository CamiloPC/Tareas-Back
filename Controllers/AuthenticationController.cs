using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Infrastructure.Services;
using TaskApi.Shared.DTOs;
using System.Data;

namespace TaskApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IServiceManager _service;
    public AuthenticationController(IServiceManager service) => _service = service;

    [HttpPost("login")]
    public async Task<IActionResult> Authenticate([FromBody] DtoUserLogin user)
    {
        if (!await _service.AuthenticationService.ValidateUser(user))
            return Unauthorized();
        var tokenDto =await _service.AuthenticationService.CreateToken(true);
        return Ok(tokenDto);
    }
}
