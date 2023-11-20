using api_miviajecr.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServiciosReservaciones
{
    public class ReservacionCheckInRepositorio : IReservacionCheckInRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public ReservacionCheckInRepositorio(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> RealizarCheckIn(ReservacionCheckIn reservacionCheckIn)
        {
            if (reservacionCheckIn != null)
            {
                _dbContext.ReservacionCheckIns.Add(reservacionCheckIn);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }
    }
}
