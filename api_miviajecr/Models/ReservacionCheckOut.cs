using System;
using System.Collections.Generic;

#nullable disable

namespace api_miviajecr.Models
{
    public partial class ReservacionCheckOut
    {
        public int IdReservacionCheckIn { get; set; }
        public int IdReservacion { get; set; }
        public bool UsuarioSalioDelAlojamiento { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
