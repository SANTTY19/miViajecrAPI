using api_miviajecr.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioInmueble
{
    public class AmenidadesPorInmuebleRepositorio : IAmenidadesPorInmuebleRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public AmenidadesPorInmuebleRepositorio(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AmenidadesPorInmueble>> ObtenerAmenidadesPorInmueble()
        {
            return await _dbContext.AmenidadesPorInmuebles.ToListAsync();
        }

        public async Task<int> InsertarAmenidadPorInmueble(AmenidadesPorInmueble amenidadPorInmueble)
        {
            if (amenidadPorInmueble != null)
            {
                _dbContext.AmenidadesPorInmuebles.Add(amenidadPorInmueble);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }
    }
}
