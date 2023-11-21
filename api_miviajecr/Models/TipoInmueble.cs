using System;
using System.Collections.Generic;

#nullable disable

namespace api_miviajecr.Models
{
    public partial class TipoInmueble
    {
       
        public int IdTipoInmueble { get; set; }
        public string TipoInmueble1 { get; set; }
        public bool EstaActivo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string IconUrl { get; set; }

    }
}
