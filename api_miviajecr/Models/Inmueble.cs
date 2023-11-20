using System;
using System.Collections.Generic;

#nullable disable

namespace api_miviajecr.Models
{
    public partial class Inmueble
    {
 
        public int IdInmueble { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoInmueble { get; set; }
        public string TituloInmueble { get; set; }
        public string DescripcionInmuebles { get; set; }
        public decimal PrecioPorNoche { get; set; }
        public decimal PromedioCalificacion { get; set; }
        public bool EstaActivo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
