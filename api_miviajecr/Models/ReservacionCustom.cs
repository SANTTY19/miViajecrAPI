using System;
using System.ComponentModel.DataAnnotations;

namespace api_miviajecr.Models
{
    public class ReservacionCustom
    {
        [Key]
        public int IdReservacion { get; set; }
        public int IdInmueble { get; set; }
        public string TituloInmueble { get; set; }
        public int IdUsuario { get; set; }
        public string NombreCompletoUsuario { get; set; }
        public decimal PromedioCalificacionUsuario { get; set; }
        public string FotoIdentificacionUsuario { get; set; }        
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public decimal? MontoDescuento { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdStatusReservacion { get; set; }
        public string StatusReservacion { get; set; }
        public bool UsuarioLlegoAlAlojamiento{ get; set; }
        public bool UsuarioSalioDelAlojamiento { get; set; }
    }
}
