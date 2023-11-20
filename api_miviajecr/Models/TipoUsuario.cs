using System;
using System.Collections.Generic;

#nullable disable

namespace api_miviajecr.Models
{
    public partial class TipoUsuario
    {
        public int IdTipoUsuario { get; set; }
        public string TipoUsuario1 { get; set; }
        public bool EstaActivo { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
