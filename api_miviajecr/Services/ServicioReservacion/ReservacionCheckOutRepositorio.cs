using api_miviajecr.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServiciosReservaciones
{
    public class ReservacionCheckOutRepositorio : IReservacionCheckOutRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public ReservacionCheckOutRepositorio(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> RealizarCheckOut(ReservacionCheckOut reservacionCheckOut)
        {
            if (reservacionCheckOut != null)
            {
                _dbContext.ReservacionCheckOuts.Add(reservacionCheckOut);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }
    }
}
