using api_miviajecr.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioInmueble
{
    public interface IInmuebleRepositorio
    {
        Task<List<InmueblesCards>> ObtenerInmueblesCards();
        Task<List<Inmueble>> ObtenerInmuebles();
        Task<string> InsertarInmueble(InmuebleCustom inmueble);
        Task<List<InmueblesCustom>> ObtenerInmueblesFavoritos(int idInmueble);
        Task<string> AgregarInmuebleAFavoritos(int idUsuario, int idInmueble);

        Task<string> VerificaCuponDescuento(int idInmueble, string cuponDescuento);
        Task<string> InsertarDescuentoPorInmueble(Descuentos descuento);
    }
}
