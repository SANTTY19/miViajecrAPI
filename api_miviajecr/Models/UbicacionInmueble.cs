using System;
using System.Collections.Generic;

#nullable disable

namespace api_miviajecr.Models
{
    public partial class UbicacionInmueble
    {
        public int IdUbicacion { get; set; }
        public int IdInmueble { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string UbicacionDetalles { get; set; }

    }
}
