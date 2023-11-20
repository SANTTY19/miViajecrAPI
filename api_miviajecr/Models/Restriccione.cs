using System;
using System.Collections.Generic;

#nullable disable

namespace api_miviajecr.Models
{
    public partial class Restriccione
    {
     
        public int IdRestriccion { get; set; }
        public string Descripcion { get; set; }
        public bool EstaActivo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string IconUrl { get; set; }
    }
}
