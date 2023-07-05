using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Infrastructure.Services;
using TaskApi.Shared.DTOs;
using System.Data;

namespace TaskApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IServiceManager _service;
    public UserController(IServiceManager service) => _service = service;

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddUser([FromBody] DtoUserRegistration userForRegistration)
    {
        var result = await
        _service.UserService.CreateUser(userForRegistration);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }
        return StatusCode(201);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> FindUserById(string id)
    {
        var res = await
        _service.UserService.FindUserById(id);

        return Ok(res);
    }

    [HttpGet("findbyemail/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> FindUserByEmail(string email)
    {
        var res = await
        _service.UserService.FindUserByEmail(email);

        return Ok(res);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateUser(string id, [FromBody] DtoUserUpdate dtoUserUpdate)
    {
        var result = await
        _service.UserService.UpdateUser(id, dtoUserUpdate);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }
        return Ok("Actualizado");
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        var result = await
         _service.UserService.DeleteUser(id);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }
        return Ok("Eliminado");
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var res = await
        _service.UserService.GetAll();

        return Ok(res);
    }

}
