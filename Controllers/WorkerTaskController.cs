using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Entities.ResponseModel;
using TaskApi.Infrastructure.Services;
using TaskApi.Shared.DTOs;

namespace TaskApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class WorkerTaskController : ControllerBase
{
    private readonly IServiceManager _service;
    public WorkerTaskController(IServiceManager service) => _service = service;

    [HttpGet("{workerId}")]
    [Authorize(Roles = "J.Depto")]
    public async Task<IActionResult> GetAll(string workerId)
    {
        var res = await
        _service.WorkerTaskService.GetAll(workerId, trackChanges: false);
        return Ok(res);
    }

    [HttpPost("{workerId}")]
    [Authorize(Roles = "J.Depto")]
    public async Task<IActionResult> CreateObj(string workerId, [FromBody] DtoWorkerTaskForInsertAndUpdate obj)
    {
        var worker = await _service.UserService.FindUserById(workerId);
        if (worker is null)
            return BadRequest("Worker not found");

        if (obj is null)
            return BadRequest("Body Object is null");

        obj.WorkerId = workerId;

        var createdObj = await _service.WorkerTaskService.CreateObj(obj);
        return Ok(createdObj);
    }

    [HttpGet("{workerId}/{id}", Name = "GetWorkerTaskById")]
    [Authorize]
    public async Task<IActionResult> GetById(string workerId, int id)
    {
        var res = await _service.WorkerTaskService.GetById(workerId, id, false);
        return Ok(res);
    }

    [HttpPut("{workerId}/{id}")]
    [Authorize(Roles = "J.Depto")]
    public async Task<IActionResult> UpdateObj(string workerId, int id,
        [FromBody] DtoWorkerTaskForInsertAndUpdate obj)
    {
        if (obj is null)
            return BadRequest("Body Object is null");
        await _service.WorkerTaskService.UpdateObj(workerId, id, obj, true);
        return Ok(obj);
    }
    [HttpPut("endtask/{workerId}/{id}")]
    [Authorize(Roles = "J.Depto")]
    public async Task<IActionResult> EndTaskObj(string workerId, int id,
        [FromBody] DtoWorkerTaskEnd obj)
    {
        if (obj is null)
            return BadRequest("Body Object is null");


        await _service.WorkerTaskService.EndTaskObj(workerId, id, obj, true);
        return Ok(obj);
    }

    [Authorize(Roles = "J.Depto")]
    [HttpDelete("{workerId}/{id}")]
    public async Task<IActionResult> DelObj(string workerId, int id)
    {
        await _service.WorkerTaskService.DeleteObj(workerId, id, false);
        return Ok("Eliminado");
    }
}