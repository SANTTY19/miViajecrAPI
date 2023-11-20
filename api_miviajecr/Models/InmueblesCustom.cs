using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_miviajecr.Models
{
    public class InmueblesCustom
    {
        [Key]
        public int IdTipoInmueble { get; set; }
        public string TituloInmueble { get; set; }
        public string DescripcionInmuebles { get; set; }
        public decimal PrecioPorNoche { get; set; }
        public decimal PromedioCalificacion { get; set; }
        public int IdImagen { get; set; }
        public string Descripcion { get; set; }
    }
}
