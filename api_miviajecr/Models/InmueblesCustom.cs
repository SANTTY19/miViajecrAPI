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
        public int inmuebleId { get; set; }

        public string inmuebleURL { get; set; }

        public string direccion { get; set; }

        public decimal calificacion { get; set; }

        public decimal precioNoche { get; set; }
    }
}


