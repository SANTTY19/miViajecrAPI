using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_miviajecr.Models
{
    public class CaracteristicasInmuebleCustom
    {
        [Key]
        public int cantidadHuespedes { get; set; }
        public int cantidadHabitaciones { get; set; }
        public int cantidadCamas { get; set; }
        public decimal cantidadBaños { get; set; }
    }
}
