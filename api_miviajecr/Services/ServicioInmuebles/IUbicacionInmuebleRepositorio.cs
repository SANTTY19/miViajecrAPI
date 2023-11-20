using api_miviajecr.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioInmueble
{
    public interface IUbicacionInmuebleRepositorio
    {
        Task<UbicacionInmueble> ObtenerUbicacionInmueble();
        Task<int> InsertarUbicacionInmueble(UbicacionInmueble ubicacionInmueble);
    }
}
