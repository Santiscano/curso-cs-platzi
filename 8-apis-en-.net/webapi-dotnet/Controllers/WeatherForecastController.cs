using Microsoft.AspNetCore.Mvc;

namespace webapi_dotnet.Controllers;

[ApiController] // este atributo indica que la clase es un controlador de API
[Route("api/[controller]")] // este atributo indica que la ruta de la API es el nombre del controlador sin la palabra Controller
public class WeatherForecastController : ControllerBase // esta clase es un controlador de API que extiende de una clase base de controlador de API
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private static List<WeatherForecast> listWeatherForecast = new List<WeatherForecast>();

    public WeatherForecastController(ILogger<WeatherForecastController> logger) // este es el constructor de la clase y logger es una instancia de la interfaz ILogger que es un mecanismo de registro en ASP.NET Core
    {
        _logger = logger;

        if(listWeatherForecast.Count == 0)
        {
            listWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Id = index, // se encarga de asignar un id al objeto
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)), // se encarga de obtener la fecha actual y sumarle un dia
                TemperatureC = Random.Shared.Next(-20, 55), // se encarga de obtener un numero aleatorio entre -20 y 55
                Summary = Summaries[Random.Shared.Next(Summaries.Length)] // se encarga de obtener un resumen aleatorio de la lista de resumenes
            }).ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")] // este atributo indica que el metodo es un metodo HTTP GET y el nombre del metodo es GetWeatherForecast
    // [Route("Get/ruta1")]
    // [Route("Get/ruta2")] // en ambas rutas se puede acceder al metodo Get
    // [Route("[action]")] // en la ruta /Getw se puede acceder al metodo Get
    public IEnumerable<WeatherForecast> Get()
    {
        return listWeatherForecast;
    }


    [HttpPost(Name = "PostWeatherForecast")] // este atributo indica que el metodo es un metodo HTTP POST y el nombre del metodo es PostWeatherForecast
    public IActionResult Post([FromBody] WeatherForecast weatherForecast) // este metodo recibe un objeto de tipo WeatherForecast
    {
        listWeatherForecast.Add(weatherForecast);
        return CreatedAtRoute("GetWeatherForecast", new { }, listWeatherForecast);
    }


    [HttpPut("{id}", Name = "PutWeatherForecast")] // este atributo indica que el metodo es un metodo HTTP PUT y el nombre del metodo es PutWeatherForecast
    public IActionResult Put(int id, [FromBody] WeatherForecast weatherForecast) // este metodo recibe un id y un objeto de tipo WeatherForecast
    {
        var weatherForecastToUpdate = listWeatherForecast.FirstOrDefault(x => x.Id == id);

        if(weatherForecastToUpdate == null)
        {
            return NotFound();
        }

        weatherForecastToUpdate.Date = weatherForecast.Date;
        weatherForecastToUpdate.TemperatureC = weatherForecast.TemperatureC;
        weatherForecastToUpdate.Summary = weatherForecast.Summary;

        return CreatedAtRoute("GetWeatherForecast", new { }, listWeatherForecast);
    }


    [HttpDelete("{id}", Name = "DeleteWeatherForecast")] // este atributo indica que el metodo es un metodo HTTP DELETE y el nombre del metodo es DeleteWeatherForecast
    public IActionResult Delete(int id) // este metodo recibe un id
    {
        var weatherForecastToDelete = listWeatherForecast.FirstOrDefault(x => x.Id == id);

        if(weatherForecastToDelete == null)
        {
            return NotFound();
        }

        listWeatherForecast.Remove(weatherForecastToDelete);

        return Ok();
    }
}
