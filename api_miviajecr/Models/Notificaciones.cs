using System;
using System.ComponentModel.DataAnnotations;

namespace api_miviajecr.Models
{
    public class Notificaciones
    {
            [Key]
            public int IdNotificacion { get; set; }
            public string Notificacion { get; set; }
            public bool FueLeida { get; set; }
            public DateTime FechaCreacion { get; set; }        
    }
}

