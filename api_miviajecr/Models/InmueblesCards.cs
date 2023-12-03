using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api_miviajecr.Models
{
    public class InmueblesCards
    {
        [Key]
        public int IdInmueble { get; set; }

        public string ImagenURL { get; set; }

        public string Direccion { get; set; }

        public decimal CalificacionPromedio { get; set; }

        public decimal PrecioPorNoche { get; set; }
    }
}
