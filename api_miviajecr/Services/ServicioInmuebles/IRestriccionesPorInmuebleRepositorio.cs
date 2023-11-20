using api_miviajecr.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioRestricciones
{
    public interface IRestriccionesPorInmuebleRepositorio
    {
        Task<List<RestriccionesPorInmueble>> ObtenerRestriccionesPorInmueble();
        Task<int> InsertarRestriccionPorInmueble(RestriccionesPorInmueble restriccionPorInmueble);
    }
}
