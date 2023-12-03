using System;
using System.ComponentModel.DataAnnotations;

namespace api_miviajecr.Models
{
    public class CorreoElectronicoConfig
    {
        [Key]
        public int Id { get; set; }
        public string CorreoElectronicoSmtp { get; set; }
        public string ContraseñaSmtp { get; set; }
        public bool UsarEstaCuenta { get; set; }
        public bool EstaActivo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
