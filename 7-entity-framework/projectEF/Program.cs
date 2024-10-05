using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectEF;
using projectEF.Models;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<TaskContext>(p => p.UseInMemoryDatabase("TasksDB")); // *logrado
builder.Services.AddSqlServer<TaskContext>(builder.Configuration.GetConnectionString("mssqlTask")); // ?TrustServerCertificate=True; solo es para local

// formas para postgresql - la primera no la he probado la segunda es la de la documentacion
// builder.Services.AddNpgsql<TaskContext>(builder.Configuration.GetConnectionString("pgTask")); // !sin probar
// builder.Services.AddDbContext<TaskContext>(p => p.UseNpgsql(builder.Configuration.GetConnectionString("pgTask"))); // !sin probar

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", ([FromServices] TaskContext dbContext) => 
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria:  " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tasks", async ([FromServices] TaskContext dbContext) => 
{
    var tasks = await dbContext.Tasks.ToListAsync();
    return Results.Ok(tasks);
});

app.MapGet("/api/taskLow", async ([FromServices] TaskContext dbContext) => 
{
    var tasks = await dbContext.Tasks.Include(p => p.Category).Where(t => t.PriorityTask == projectEF.Models.Priority.Low).ToListAsync();
    return Results.Ok(tasks);
});

app.MapGet("/api/tasks/{id}", async ([FromServices] TaskContext dbContext, Guid id) => 
{
    var task = await dbContext.Tasks.FindAsync(id);
    return task is not null ? Results.Ok(task) : Results.NotFound();
});

app.MapGet("/api/tasks/{id}/category", async ([FromServices] TaskContext dbContext, Guid id) => 
{
    var task = await dbContext.Tasks.Include(t => t.Category).FirstOrDefaultAsync(t => t.TaskId == id);
    return task is not null ? Results.Ok(task.Category) : Results.NotFound();
});

app.MapPost("/api/tasks", async ([FromServices] TaskContext dbContext, [FromBody] projectEF.Models.Task task) => 
{
    task.TaskId = Guid.NewGuid();
    task.DateCreation = DateTime.Now;
    // dbContext.Tasks.Add(task);
    await dbContext.Tasks.AddAsync(task);
    await dbContext.SaveChangesAsync();
    return Results.Created($"/api/tasks/{task.TaskId}", task);
});

app.MapPut("/api/tasks/{id}", async (
    [FromServices] TaskContext dbContext, 
    [FromBody] projectEF.Models.Task task,
    [FromRoute] Guid id ) => 
{
    var taskExist = await dbContext.Tasks.FindAsync(id);
    if (taskExist is null) return Results.NotFound();
    
    task.CategoryId = taskExist.CategoryId;
    task.Title = taskExist.Title;
    task.PriorityTask = taskExist.PriorityTask;
    task.Description = taskExist.Description;

    await dbContext.SaveChangesAsync();
    return Results.Ok(task);
});

app.MapDelete("/api/tasks/{id}", async (
    [FromServices] TaskContext dbContext, 
    Guid id) => 
{
    var task = await dbContext.Tasks.FindAsync(id);
    if (task is null) return Results.NotFound();
    
    dbContext.Tasks.Remove(task);
    await dbContext.SaveChangesAsync();
    
    return Results.NoContent();
});

app.MapGet("/createCategory", async ([FromServices] TaskContext dbContext) => 
{
    var category = new Category { CategoryId = Guid.NewGuid(), Name = "Personal", Description = "Tareas personales" };
    await dbContext.Categories.AddAsync(category);
    await dbContext.SaveChangesAsync();
    return Results.Created($"/api/tasks/{category.CategoryId}", category);
});

app.MapGet("/getCategory", async ([FromServices] TaskContext dbContext) => 
{
    var category = await dbContext.Categories.ToListAsync();
    return Results.Ok(category);
});


app.Run();
