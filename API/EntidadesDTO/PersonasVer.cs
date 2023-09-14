using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesDTO
{
    public class PersonasVer
    {
        public Guid id { get; set; }
        public string nombre { get; set; }

        public DateTime fechaNacimiento { get; set; }

        public string? telefono { get; set; }
    }
}
