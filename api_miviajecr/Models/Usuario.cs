using System;
using System.Collections.Generic;

#nullable disable

namespace api_miviajecr.Models
{
    public partial class Usuario
    {
       

        public int IdUsuario { get; set; }
        public int IdTipoUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
        public string NumeroTelefono { get; set; }
        public string Contraseña { get; set; }
        public string FotoIdentificacion { get; set; }
        public decimal PromedioCalificacion { get; set; }
        public bool SesionActiva { get; set; }
        public string Token { get; set; }
        public bool EstaActivo { get; set; }
        public bool FueValidado { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
