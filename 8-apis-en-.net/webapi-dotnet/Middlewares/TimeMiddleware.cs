
public class TimeMiddleware {
    readonly RequestDelegate _next; // RequestDelegate es un delegado que representa un metodo que puede procesar una solicitud HTTP, este _next se usara para invocar el siguiente middleware en la canalizacion

    public TimeMiddleware(RequestDelegate nextRequest) // este es el constructor de la clase y recibe un RequestDelegate
    {
        _next = nextRequest; // se asigna el RequestDelegate al campo _next
    }

    public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context) // viene por defecto en todos los middlewares y recibe un HttpContext
    {
        await _next(context); // se invoca el siguiente middleware en la canalizacion
        
        if( context.Request.Query.Any( q => q.Key == "time" ) ) // se verifica si en la peticion hay un parametro llamado time
        {
            await context.Response.WriteAsync( DateTime.Now.ToString() ); // se escribe en la respuesta la fecha y hora actual del servidor
        }
    }
}

public static class TimeMiddlewareExtension
{
    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder) // este metodo extiende la interfaz IApplicationBuilder y recibe un IApplicationBuilder
    {
        return builder.UseMiddleware<TimeMiddleware>(); // se agrega el middleware TimeMiddleware a la canalizacion
    }
}