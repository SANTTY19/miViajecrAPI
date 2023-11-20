using System;
using System.Collections.Generic;

#nullable disable

namespace api_miviajecr.Models
{
    public partial class StatusDenuncium
    {
     
        public int IdStatusDenuncia { get; set; }
        public string StatusDenuncia { get; set; }
        public bool EstaActivo { get; set; }

    }
}
