using api_miviajecr.Models;
using System.Threading.Tasks;

namespace api_miviajecr.Services
{
    public interface ICotizacion
    {
        Task<CotizacionModel> CalcularCotizacion(int inmuebleId, int cantidadHuespedes, int cantidadDias);
    }
}
