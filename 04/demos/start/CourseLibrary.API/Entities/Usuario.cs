using System.ComponentModel.DataAnnotations;

namespace CourseLibrary.API.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public ICollection<Conversion> Conversiones { get; set; }
    = new List<Conversion>();

    }
}
