using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_miviajecr.Models
{
    public class Descuentos
    {
        public int IdInmueble { get; set; }
        public string  CodigoDescuento { get; set; }
        public decimal MontoDescuento { get; set; }
    }
}
