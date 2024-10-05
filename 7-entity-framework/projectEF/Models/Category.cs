using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace projectEF.Models
{
    public class Category
    {
        // [Key]
        public Guid CategoryId { get; set; }

        // [Required]
        // [MaxLength(150)]
        public string Name { get; set; }


        public string Description { get; set; }
        public int Weight { get; set; }

        [JsonIgnore] // Ignora la propiedad al serializar a JSON - es decir no se mostrara en la respuesta cuando se llamen las tareas
        public virtual ICollection<Task> Tasks { get; set; }
    }
}

