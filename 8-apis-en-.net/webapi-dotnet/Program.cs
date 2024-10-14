using webapi_dotnet;
using webapi_dotnet.Services;

var builder = WebApplication.CreateBuilder(args); // esta linea se encarga de crear el host de la aplicacion web y configurar el entorno de la aplicacion web con la configuracion predeterminada

// Add services to the container.

builder.Services.AddControllers(); // se encarga de agregar los servicios de controladores a la aplicacion web que se crean en el proyecto
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // se encarga de agregar los servicios de explorador de API de puntos finales a la aplicacion web que se crean en el proyecto - es decir, se encarga de agregar la documentacion de la API
builder.Services.AddSwaggerGen(); // se encarga de agregar los servicios de generacion de Swagger a la aplicacion web que se crean en el proyecto - es decir, se encarga de agregar la documentacion de la API

// configuramos entityframework
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("mssqlTask")); // se encarga de agregar el servicio de SQL Server a la aplicacion web que se crea en el proyecto

// builder.Services.AddScoped(p => new HelloWorldService()); // cada que se inyecte la interfaz IHelloWorldService se creara una nueva instancia de HelloWorldService
builder.Services.AddScoped<IHelloWorldService, HelloWorldService>(); // cada que se implemente la interfaz IHelloWorldService se creara una nueva instancia de HelloWorldService

// Inyeccion de dependencias de los servicios creados.
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<ITaskServices, TaskServices>();



var app = builder.Build(); // se encarga de construir la aplicacion web con la configuracion predeterminada, es decir hace el build de la aplicacion web

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // si el entorno de la aplicacion web es de desarrollo
{
    app.UseSwagger(); // se encarga de usar Swagger en la aplicacion web
    app.UseSwaggerUI(); // se encarga de usar SwaggerUI en la aplicacion web
}

// app.UseHttpsRedirection(); // se encarga de redirigir el trafico HTTP a HTTPS

app.UseAuthorization(); // se encarga de usar la autorizacion en la aplicacion web la cual se configura en el proyecto en la carpeta Properties
app.UseTimeMiddleware(); // se encarga de usar el middleware TimeMiddleware en la aplicacion web
app.MapControllers(); // se encarga de mapear todos los controladores de la aplicacion web
// app.UseCors(); // se encarga de usar CORS en la aplicacion web
// app.UseWelcomePage(); // se encarga de usar la pagina de bienvenida en la aplicacion web
// app.UseTimeMiddleware(); // este es un middleware personalizado creado en la carpeta Middlewares

app.Run(); // punto de entrada de la aplicacion web
