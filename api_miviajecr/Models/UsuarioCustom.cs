using System;
using System.ComponentModel.DataAnnotations;

namespace api_miviajecr.Models
{
    public class UsuarioCustom
    {   
        [Key]
        public int IdUsuario { get; set; }
        public string TipoUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
        public string NumeroTelefono { get; set; }
        public string FotoIdentificacion { get; set; }
        public decimal PromedioCalificacion { get; set; }
        public bool SesionActiva { get; set; }
        public bool FueValidado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
