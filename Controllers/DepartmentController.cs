using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Entities.ResponseModel;
using TaskApi.Infrastructure.Services;
using TaskApi.Shared.DTOs;

namespace TaskApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly IServiceManager _service;
    public DepartmentController(IServiceManager service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var res = await
        _service.DepartmentService.GetAll(trackChanges: false);
        return Ok(res);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateObj([FromBody] DtoDepartmentForInsertAndUpdate obj)
    {
        if (obj is null)
            return BadRequest("Body Object is null");

        var createdObj = await _service.DepartmentService.CreateObj(obj);
        return Ok(createdObj);
    }

    [HttpGet("{id}", Name = "GetDepartmentById")]
    [Authorize]
    public async Task<IActionResult> GetById(int id)
    {
        var res = await _service.DepartmentService.GetById(id, false);
        return Ok(res);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateObj(int id, [FromBody] DtoDepartmentForInsertAndUpdate obj)
    {
        if (obj is null)
            return BadRequest("Body Object is null");
        await _service.DepartmentService.UpdateObj(id, obj, true);
        return Ok(obj);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DelObj(int id)
    {
        await _service.DepartmentService.DeleteObj(id, false);

        return Ok("Eliminado");
    }
}