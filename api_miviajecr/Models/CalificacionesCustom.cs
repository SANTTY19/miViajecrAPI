using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_miviajecr.Models
{
    public class CalificacionesCustom
    {

        [Key]
        public int IdCalificacionReserva { get; set; }
        public int IdInmueble { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public decimal PromedioCalificacion { get; set; }
        public string Comentarios { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
