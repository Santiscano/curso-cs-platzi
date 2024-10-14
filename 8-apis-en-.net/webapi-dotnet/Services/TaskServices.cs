using webapi_dotnet.Models;

namespace webapi_dotnet.Services;

public class TaskServices : ITaskServices
{
    TareasContext context;

    public TaskServices(TareasContext context)
    {
        this.context = context;
    }

    public IEnumerable<Tarea> GetTasks()
    {
        return context.Tareas;
    }

    public async void SaveTask(Tarea task)
    {
        context.Add(task);
        await context.SaveChangesAsync();
    }

    public async void UpdateTask(Guid id, Tarea task)
    {
        var taskToUpdate = context.Tareas.Find(id);

        if (taskToUpdate != null)
        {
            taskToUpdate.Titulo = task.Titulo;
            taskToUpdate.Descripcion = task.Descripcion;
            taskToUpdate.PrioridadTarea = task.PrioridadTarea;
            taskToUpdate.FechaCreacion = task.FechaCreacion;
            taskToUpdate.CategoriaId = task.CategoriaId;

            await context.SaveChangesAsync();
        }
    }

    public async void DeleteTask(Guid id)
    {
        var taskToDelete = context.Tareas.Find(id);
        if (taskToDelete != null)
        {
            context.Remove(taskToDelete);
            await context.SaveChangesAsync();
        }
    }
}


public interface ITaskServices
{
    IEnumerable<Tarea> GetTasks();
    void SaveTask(Tarea task);
    void UpdateTask(Guid id, Tarea task);
    void DeleteTask(Guid id);
}