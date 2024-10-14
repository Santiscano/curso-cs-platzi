using Microsoft.AspNetCore.Mvc;

namespace webapi_dotnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController: ControllerBase
{
    IHelloWorldService _helloWorldService;
    TareasContext _context;

    public HelloWorldController(IHelloWorldService helloWorldService, TareasContext context)
    {
        _helloWorldService = helloWorldService;
        _context = context;
    }

    // [HttpGet]
    // public IActionResult Get()
    // {
    //     return Ok(_helloWorldService.GetMessage());
    // }

    [HttpGet("db")]
    public IActionResult GetDb()
    {
        return Ok(_context.Database.EnsureCreated());
    }
}