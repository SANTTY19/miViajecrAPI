using System;
using System.Collections.Generic;

#nullable disable

namespace api_miviajecr.Models
{
    public partial class ReservacionCheckIn
    {
        public int IdReservacionCheckIn { get; set; }
        public int IdReservacion { get; set; }
        public bool UsuarioLlegoAlAlojamiento { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
