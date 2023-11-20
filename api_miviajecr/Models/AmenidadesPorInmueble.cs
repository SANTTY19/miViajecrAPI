using System;
using System.Collections.Generic;

#nullable disable

namespace api_miviajecr.Models
{
    public partial class AmenidadesPorInmueble
    {
        public int IdAmenidad { get; set; }
        public int IdInmueble { get; set; }
        public bool EstaActivo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdAmenidadesPorInmueble { get; set; }

    }
}
