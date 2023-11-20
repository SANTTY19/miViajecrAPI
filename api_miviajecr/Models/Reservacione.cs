using System;
using System.Collections.Generic;

#nullable disable

namespace api_miviajecr.Models
{
    public partial class Reservacione
    {
       
        public int IdReservacion { get; set; }
        public int IdInmueble { get; set; }
        public int IdUsuario { get; set; }
        public int IdStatusReservacion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public decimal? MontoDescuento { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTime FechaCreacion { get; set; }

      
    }
}
