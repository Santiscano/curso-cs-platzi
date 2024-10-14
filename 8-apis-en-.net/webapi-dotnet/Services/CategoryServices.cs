
using webapi_dotnet.Models;

namespace webapi_dotnet.Services;


public class CategoryServices : ICategoryServices
{
    TareasContext context;

    public CategoryServices(TareasContext context)
    {
        this.context = context;
    }
    public IEnumerable<Categoria> GetCategories()
    {
        return context.Categorias;
    }

    public async void SaveCategory(Categoria category)
    {
        context.Add(category);
        await context.SaveChangesAsync();
    }

    public async void UpdateCategory(Guid id, Categoria category)
    {
        // var categoryToUpdate = context.Categorias.FirstOrDefault(p => p.CategoriaId == id);
        var categoryToUpdate = context.Categorias.Find(id);

        if (categoryToUpdate != null)
        {
            categoryToUpdate.Nombre = category.Nombre;
            categoryToUpdate.Descripcion = category.Descripcion;
            categoryToUpdate.Peso = category.Peso;
            
            await context.SaveChangesAsync();
        }
    }

    public async void DeleteCategory(Guid id)
    {
        var categoryToDelete = context.Categorias.Find(id);
        if (categoryToDelete != null)
        {
            context.Remove(categoryToDelete);
            await context.SaveChangesAsync();
        }
    }
}


public interface ICategoryServices
{
    IEnumerable<Categoria> GetCategories();
    void SaveCategory(Categoria category);
    void UpdateCategory(Guid id, Categoria category);
    void DeleteCategory(Guid id);
}