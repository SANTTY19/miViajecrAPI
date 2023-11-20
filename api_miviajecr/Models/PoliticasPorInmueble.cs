using System;
using System.Collections.Generic;

#nullable disable

namespace api_miviajecr.Models
{
    public partial class PoliticasPorInmueble
    {
        public int IdPolitica { get; set; }
        public int IdInmueble { get; set; }
        public bool EstaActivo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdPoliticasPorInmueble { get; set; }

      
    }
}
