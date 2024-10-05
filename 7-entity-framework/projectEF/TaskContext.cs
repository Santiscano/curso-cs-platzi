using Microsoft.EntityFrameworkCore;
using projectEF.Models;


namespace projectEF
{
    public class TaskContext: DbContext
    {
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options): base(options) { }

        // Esta se usa es para utilizar Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(category => 
            {
                category.ToTable("Category");
                category.HasKey(c => c.CategoryId);
                category.Property(c => c.Name).HasMaxLength(150).IsRequired();
                category.Property(c => c.Description).IsRequired(false);
                category.Ignore(c => c.Weight);

            });

            modelBuilder.Entity<Models.Task>(task => {
                task.ToTable("Task");   // indica el nombre de la tabla, "singular para la norma de normalizacion de sql"
                task.HasKey(t => t.TaskId); // indica la llave primaria
                task.HasOne(t => t.Category).WithMany(c => c.Tasks).HasForeignKey(t => t.CategoryId); // relaciona con la tabla Category indicando que es de uno a muchos, es decir, una categoria puede tener muchas tasks
                task.Property(t => t.Title).HasMaxLength(200).IsRequired();
                task.Property(t => t.Description).IsRequired(false);
                task.Property(t => t.PriorityTask).HasConversion(
                    p => p.ToString(),
                    p => (Priority)Enum.Parse(typeof(Priority), p)
                );
                task.Property(t => t.DateCreation);
                task.Ignore(t => t.Resumen); // no se mapea en la base de datos

            });
        }
    }
}