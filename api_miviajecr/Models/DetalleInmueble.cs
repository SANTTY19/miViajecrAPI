using System;
using System.ComponentModel.DataAnnotations;

namespace api_miviajecr.Models
{
    public class DetalleInmueble
    {
        [Key]
        public int IdInmueble { get; set; }
        public string TituloInmueble { get; set; }
        public string NombreUsuario { get; set; }
        public string DescripcionInmuebles { get; set; }
        public decimal PrecioPorNoche { get; set; }
        public decimal PromedioCalificacion { get; set; }
        public string ServicioDescripcion { get; set; }
        public string AmenidadDescripcion { get; set; }
        public string PoliticaDescripcion { get; set; }
        public string RestriccionDescripcion { get; set; }
        public string TipoInmueble { get; set; }
        public string CaracteristicaDescripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string ImagenDescripcion { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string UbicacionDetalles { get; set; }
    }
}
