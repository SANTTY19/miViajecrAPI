using System;
using System.Collections.Generic;

#nullable disable

namespace api_miviajecr.Models
{
    public partial class CalificacionReservacione
    {
        public int IdCalificacionReserva { get; set; }
        public int IdReservacion { get; set; }
        public int IdUsuario { get; set; }
        public decimal PromedioCalificacion { get; set; }
        public string Comentarios { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
