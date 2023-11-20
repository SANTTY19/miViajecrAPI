using api_miviajecr.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioInmuebles
{
    public interface IDetalle
    {
        Task<List<DetalleInmueble>> ObtenerInformacionInmuebles();
    }
}
