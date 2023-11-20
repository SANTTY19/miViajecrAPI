using System;
using System.Collections.Generic;

#nullable disable

namespace api_miviajecr.Models
{
    public partial class DisponibilidadInmueble
    {
        public int IdDisponibilidad { get; set; }
        public int IdInmueble { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaCreacion { get; set; }

       
    }
}
