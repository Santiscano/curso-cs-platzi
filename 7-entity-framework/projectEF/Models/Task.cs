using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectEF.Models
{

    [Table("Tasks")] // aqui se le da el nombre a la tabla
    public class Task
    {
        // [Key]
        public Guid TaskId { get; set; }
        
        // [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }

        // [Required]
        // [MaxLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }
        public Priority PriorityTask { get; set; }
        public DateTime DateCreation { get; set; }

        // relacionar tablas
        public virtual Category Category { get; set; }

        // [NotMapped] // no se mapea en la base de datos
        public string Resumen { get; set; }
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }
}
