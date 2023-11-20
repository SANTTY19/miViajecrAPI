using api_miviajecr.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioInmueble
{
    public interface IAmenidadesPorInmuebleRepositorio
    {
        Task<List<AmenidadesPorInmueble>> ObtenerAmenidadesPorInmueble();
        Task<int> InsertarAmenidadPorInmueble(AmenidadesPorInmueble amenidadPorInmueble);
    }
}
