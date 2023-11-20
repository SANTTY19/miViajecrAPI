using api_miviajecr.Models;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServiciosReservaciones
{
    public interface IReservacionCheckInRepositorio
    {
        Task<int> RealizarCheckIn(ReservacionCheckIn reservacionCheckIn);
    }
}
