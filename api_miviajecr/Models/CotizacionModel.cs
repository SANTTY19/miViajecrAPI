using System.ComponentModel.DataAnnotations;

namespace api_miviajecr.Models
{
    public class CotizacionModel
    {
        [Key]
        public int Id { get; set; }

        public int InmuebleId { get; set; }
        public int CantidadHuespedes { get; set; }
        public int CantidadDias { get; set; }
        public decimal PrecioTotalPorNocheConImpuestos { get; set; }
        public decimal PrecioTotalConImpuestosPorDias { get; set; }
    }
}
