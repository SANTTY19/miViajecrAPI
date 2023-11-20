using api_miviajecr.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServiciosReservaciones
{
    public interface ICalificacionReservacioneRepositorio
    {
        Task<List<CalificacionReservacione>> ObtenerCalificacionesReservaciones();
        Task<int> InsertarCalificacionReservacion(CalificacionReservacione calificacionReservacion);
    }
}
