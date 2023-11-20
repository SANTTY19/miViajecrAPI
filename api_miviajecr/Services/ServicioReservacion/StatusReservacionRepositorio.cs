using api_miviajecr.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServiciosReservaciones
{
    public class StatusReservacionRepositorio : IStatusReservacionRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public StatusReservacionRepositorio(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<StatusReservacion>> ObtenerStatusReservaciones()
        {
            return await _dbContext.StatusReservacions.ToListAsync();
        }
    }
}
