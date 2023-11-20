using api_miviajecr.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioInmueble
{
    public interface ICaracteristicasInmuebleRepositorio
    {
        Task<List<CaracteristicasInmueble>> ObtenerCaracteristicasInmueble();
        Task<int> InsertarCaracteristicaInmueble(CaracteristicasInmueble caracteristicaInmueble);
    }
}
