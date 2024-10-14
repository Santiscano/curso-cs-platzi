using Microsoft.AspNetCore.Mvc;
using webapi_dotnet.Models;
using webapi_dotnet.Services;

namespace webapi_dotnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    protected readonly ITaskServices _taskServices;
    public TaskController(ITaskServices taskServices)
    {
        _taskServices = taskServices;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_taskServices.GetTasks());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Tarea task)
    {
        _taskServices.SaveTask(task);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Tarea task)
    {
        _taskServices.UpdateTask(id, task);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _taskServices.DeleteTask(id);
        return Ok();
    }
}