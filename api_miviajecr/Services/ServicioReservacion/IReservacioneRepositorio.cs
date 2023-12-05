using api_miviajecr.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServiciosReservaciones
{
    public interface IReservacioneRepositorio
    {
        Task<List<Reservacione>> ObtenerReservaciones();
        Task<int> InsertarReservacion(Reservacione reservacion);
        Task<List<CalificacionesCustom>> ObtenerInfoReservacion(int idInmueble);

    }
}
