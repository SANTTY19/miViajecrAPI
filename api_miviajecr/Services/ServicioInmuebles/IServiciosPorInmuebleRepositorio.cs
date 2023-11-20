using api_miviajecr.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioInmueble
{
    public interface IServiciosPorInmuebleRepositorio
    {
        Task<List<ServiciosPorInmueble>> ObtenerServiciosPorInmueble();
        Task<int> InsertarServicioPorInmueble(ServiciosPorInmueble servicioPorInmueble);
    }
}
