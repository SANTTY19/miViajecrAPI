using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_miviajecr.Models
{
    public class InmuebleCustom
    {
        [Key]
        public int IdInmueble { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoInmueble { get; set; }
        public string TituloInmueble { get; set; }
        public string DescripcionInmueble { get; set; }
        public decimal PrecioPorNoche { get; set; }
        public List<ImagenesInmueble> Imagenes{ get; set; }
        public List<ServiciosPorInmueble> Servicios { get; set; }
        public List<AmenidadesPorInmueble> Amenidades { get; set; }
        public List<RestriccionesPorInmueble> Restricciones { get; set; }
        public List<PoliticasPorInmueble> Politicas { get; set; }
        public List<CaracteristicasInmuebleCustom> Caracteristicas { get; set; }
        public List<UbicacionInmueble> Ubicacion { get; set; }



    }
}
