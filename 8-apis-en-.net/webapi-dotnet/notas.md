# **Comando para crear un proyecto**
```shell
# navegar a la carpeta donde se hara
$ cd source/repos
$ mkdir my-project
$ cd my-project

# ejecutar comando de .net
$ dotnet new --list # ver opciones de cosas por crear
$ dotnet new webapi --use-controllers -n nombreProyectoInterno # crear proyecto -n es opcional
$ code . # abrir el proyecto
$ dotnet run # correr api
```

# **Análisis del template para APIs de .NET**
---
Cuando ejecutamos el comando `dotnet new webapi` el CLI de dotnet nos crea un proyecto listo para ejecutar y realizar pruebas, veamos que contiene este proyecto.

!https://prod-files-secure.s3.us-west-2.amazonaws.com/403c0419-efe8-47a1-a35b-04b72a799fbf/9b1e03dc-5afe-4d89-bbf6-ebe8c8af96ad/Untitled.png

- **`Program.cs`**: Este archivo contiene la clase principal del programa, que es el punto de entrada para la aplicación. También contiene la lógica para iniciar el host de la aplicación y configurar el enrutamiento.
- **`Controllers`**: Este directorio contiene los controladores de la API. Cada controlador es responsable de manejar una o varias solicitudes HTTP y devolver una respuesta.
- **`appsettings.json`**: Este archivo contiene la configuración de la aplicación, como las opciones de conexión a la base de datos y las opciones de configuración personalizadas.
- **`Properties`**: Este directorio contiene información sobre el proyecto, como la información de versión y la información de compilación.
- **`Models`**: Este directorio contiene los modelos de datos utilizados por la API. Los modelos representan los datos que se manejan en la API, como los recursos que se están exponiendo.

### **Patron MVC**
MVC es el acrónimo de Model-View-Controller, que es un patrón de arquitectura de software utilizado en desarrollo de aplicaciones. Se utiliza para separar la lógica de negocios, la lógica de presentación y la lógica de control en componentes independientes.

1. Modelo (Model): Es la capa de datos y lógica de negocios de la aplicación. Se encarga de representar los datos y las operaciones que se realizan sobre ellos.
2. Vista (View): Es la capa de presentación, se encarga de mostrar los datos al usuario y de recibir su entrada.
3. Controlador (Controller): Es la capa de control, que se encarga de coordinar las acciones entre el modelo y la vista. Recibe las solicitudes del usuario a través de la vista y actúa sobre el modelo para realizar las acciones necesarias.


# **Manejo de rutas**
---
En `***.NET***`, puedes usar el enrutamiento para definir cómo deben estructurarse las URL de tu API y cómo deben asociarse con los métodos en los controladores.

Nuestra API de **`*.Net*`** nos permite personalizar la ruta desde la cual se prodra acceder a los servicio:
```cs
[ApiController]
[Route("api/[controller]")]

public class WeatherForecastController : ControllerBase {}
```

El atributo **`Route`** es un atributo de enrutamiento que se utiliza para definir la ruta base para las acciones en un controlador. En este caso, la ruta base para las acciones en este controlador será "`api/[controller]`", donde "`[controller]`" se reemplazará automáticamente con el nombre del controlador sin la palabra "Controller". Por ejemplo, si el nombre del controlador es "WeatherForecastController", la ruta base para las acciones será "api/WeatherForecast".
```cs
[Route("[action]")]
	public IEnumerable<WeatherForecast> Getw() {}
```

El atributo **`Route`** se utiliza para definir la ruta para la acción. En este caso, la ruta será "`[action]`", donde "`[action]`" se reemplazará automáticamente con el nombre del método de acción. Por ejemplo, si el nombre del método de acción es "Get", la ruta para esta acción será "Get".



# **Inyeccion de dependiencias**
La inyeccion de dependiencias, se debe aplicar de la siguiente manera

1. se crea una clase y una interface en los servicios, en esta clase se indica la logica de negocio como por ejemplo los metodos que tendra esta clase y que hara con ellos
```cs
public class HelloWorldService: IHelloWorldService
{
    public string GetMessage()
    {
        return "Hello World!";
    }
}
```

2. se crea una interface que indique los metodos pero sin su implementacion, es decir como si fueran metodos abstractos
```cs
public interface IHelloWorldService
{
    string GetMessage();
}
```

3. en el archivo program.cs se implementa la siguiente linea de codigo antes del build
```cs
// builder.Services.AddScoped<Interface, Service>(); - maqueta de uso
// builder.Services.AddScoped<IHelloWorldService>(p => new HelloWorldService()); // de esta forma se podrian pasar parametros
builder.Services.AddScoped<IHelloWorldService, HelloWorldService>(); // ejemplo
var app = builder.Build();
```

4. En el controlador donde se implemente solo es necesario definirla en el constructor utilizando la interface como el tipo de dato que recibe "se inyecta":
```cs
using Microsoft.AspNetCore.Mvc;

namespace webapi_dotnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController: ControllerBase
{
    IHelloWorldService _helloWorldService; // tipo de dato IHelloWorldService

    public HelloWorldController(IHelloWorldService helloWorldService) // de define que el dato inyectado es de ese tipo
    {
        _helloWorldService = helloWorldService;
    }

    public IActionResult Get()
    {
        return Ok(_helloWorldService.GetMessage());
    }
}
```

## Logging
para utilizar el logger de .net configurado por defecto se puede utilizar creandolo en el constructor
```cs
public class HelloWorldController: ControllerBase
{
    private readonly ILogger<HelloWorldController> _logger;

    public HelloWorldController(ILogger<HelloWorldController> logger) // de define que el dato inyectado es de ese tipo
    {
        _logger = logger
    }

    public IActionResult Get()
    {
        return Ok(_helloWorldService.GetMessage());
    }
}
```


## Swagger