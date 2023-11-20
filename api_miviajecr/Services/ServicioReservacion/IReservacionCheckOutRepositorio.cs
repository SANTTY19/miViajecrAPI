using api_miviajecr.Models;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServiciosReservaciones
{
    public interface IReservacionCheckOutRepositorio
    {
        Task<int> RealizarCheckOut(ReservacionCheckOut reservacionCheckOut);
    }
}
