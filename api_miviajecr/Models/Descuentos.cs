using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_miviajecr.Models
{
    public class Descuentos
    {
        [Key]
        public int IdDescuento { get; set; }
        public int IdInmueble { get; set; }
        public string  CodigoDescuento { get; set; }
        public decimal MontoDescuento { get; set; }
    }
}
