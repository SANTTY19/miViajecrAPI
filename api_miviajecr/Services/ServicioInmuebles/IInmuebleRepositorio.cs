using api_miviajecr.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioInmueble
{
    public interface IInmuebleRepositorio
    {
        Task<List<Inmueble>> ObtenerInmuebles();
        Task<int> InsertarInmueble(Inmueble inmueble);
        Task<List<InmueblesCustom>> ObtenerInmueblesFavoritos(int idInmueble);
        Task<string> AgregarInmuebleAFavoritos(int idUsuario, int idInmueble);
    }
}
