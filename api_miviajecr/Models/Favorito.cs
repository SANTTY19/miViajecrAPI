using System;
using System.Collections.Generic;

#nullable disable

namespace api_miviajecr.Models
{
    public partial class Favorito
    {
        public int IdFavorito { get; set; }
        public int IdInmueble { get; set; }
        public int IdUsuario { get; set; }
        public bool EstaActivo { get; set; }
        public DateTime FechaCreacion { get; set; }

     
    }
}
