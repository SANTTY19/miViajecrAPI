using api_miviajecr.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServiciosReservaciones
{
    public interface IStatusReservacionRepositorio
    {
        Task<List<StatusReservacion>> ObtenerStatusReservaciones();
    }
}
