using api_miviajecr.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioInmueble
{
    public interface ITipoInmuebleRepositorio
    {
        Task<List<TipoInmueble>> ObtenerTiposInmuebles();
        Task<int> InsertarTipoInmueble(TipoInmueble tipoInmueble);
    }
}
