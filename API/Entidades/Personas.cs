
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Personas
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        [MaxLength(50)]
        public string nombre { get; set; }

        [Required]
        public DateTime fechaNacimiento { get; set; }

        [MaxLength(25)]
        public string? telefono { get; set; }
    }
}