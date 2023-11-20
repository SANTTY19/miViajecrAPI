using api_miviajecr.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioInmueble
{
    public class DisponibilidadInmuebleRepositorio : IDisponibilidadInmuebleRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public DisponibilidadInmuebleRepositorio(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DisponibilidadInmueble>> ObtenerDisponibilidadInmueble()
        {
            return await _dbContext.DisponibilidadInmuebles.ToListAsync();
        }

        public async Task<int> InsertarDisponibilidadInmueble(DisponibilidadInmueble disponibilidadInmueble)
        {
            if (disponibilidadInmueble != null)
            {
                _dbContext.DisponibilidadInmuebles.Add(disponibilidadInmueble);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }
    }
}