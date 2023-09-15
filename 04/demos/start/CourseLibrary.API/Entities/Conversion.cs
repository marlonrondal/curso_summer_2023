using System.ComponentModel.DataAnnotations.Schema;

namespace CourseLibrary.API.Entities
{
    public class Conversion
    {
        public int Id { get; set; }


        
        public int MonedaOrigenId { get; set; }

        [ForeignKey("MonedaOrigenId")]
        public Moneda MonedaOrigen { get; set; }


        public int MonedaDestinoId { get; set; }

        [ForeignKey("MonedaDestinoId")]
        public Moneda MonedaDestino { get; set; }


        public double Factor { get; set; }

        public double Valor { get; set; }

        public DateTime FechaConversion { get; set; }

        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set;}



    }
}
