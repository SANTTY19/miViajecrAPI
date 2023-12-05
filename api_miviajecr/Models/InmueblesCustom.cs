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
        public int IdInmueble { get; set; }

        public string ImagenURL { get; set; }

        public string Direccion { get; set; }

        public decimal CalificacionPromedio { get; set; }

        public decimal PrecioPorNoche { get; set; }
    }
}


