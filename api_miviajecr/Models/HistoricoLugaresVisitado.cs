using System;
using System.Collections.Generic;

#nullable disable

namespace api_miviajecr.Models
{
    public partial class HistoricoLugaresVisitado
    {
        public int IdHistoricoLugarVisitado { get; set; }
        public int IdReservacion { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
