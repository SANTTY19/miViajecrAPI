using api_miviajecr.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServiciosReservaciones
{
    public class CalificacionReservacioneRepositorio : ICalificacionReservacioneRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public CalificacionReservacioneRepositorio(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CalificacionReservacione>> ObtenerCalificacionesReservaciones()
        {
            return await _dbContext.CalificacionReservaciones.ToListAsync();
        }

        public async Task<int> InsertarCalificacionReservacion(CalificacionReservacione calificacionReservacion)
        {
            if (calificacionReservacion != null)
            {
                _dbContext.CalificacionReservaciones.Add(calificacionReservacion);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }
    }
}
