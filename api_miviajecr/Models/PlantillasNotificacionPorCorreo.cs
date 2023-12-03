using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_miviajecr.Models
{
    public class PlantillasNotificacionPorCorreo
    {
        [Key]
        public int IdPlantilla { get; set; }
        public string PlantillaHtml { get; set; }
        public string SujetoPlantilla { get; set; }
        public string TituloPlantilla { get; set; }                       
        public string CuerpoPlantilla { get; set; }
        public string PieDePaginaPlantilla { get; set; }
        public bool EstaActivo { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
