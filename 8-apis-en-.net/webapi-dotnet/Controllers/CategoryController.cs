using Microsoft.AspNetCore.Mvc;
using webapi_dotnet.Models;
using webapi_dotnet.Services;

namespace webapi_dotnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    protected readonly ICategoryServices _categoryServices;

    public CategoryController(ICategoryServices categoryServices)
    {
        _categoryServices = categoryServices;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_categoryServices.GetCategories());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Categoria category)
    {
        _categoryServices.SaveCategory(category);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Categoria category)
    {
        _categoryServices.UpdateCategory(id, category);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _categoryServices.DeleteCategory(id);
        return Ok();
    }
}