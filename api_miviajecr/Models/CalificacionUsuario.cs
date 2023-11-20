using System;
using System.Collections.Generic;

#nullable disable

namespace api_miviajecr.Models
{
    public partial class CalificacionUsuario
    {
        public int IdCalificacionUsuario { get; set; }
        public int IdUsuarioCalificado { get; set; }
        public int IdUsuarioCalificador { get; set; }
        public decimal PromedioCalificacion { get; set; }
        public string Comentarios { get; set; }
        public DateTime FechaCreacion { get; set; }

       
    }
}
