using api_miviajecr.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioInmueble
{
    public class ServiciosPorInmuebleRepositorio : IServiciosPorInmuebleRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public ServiciosPorInmuebleRepositorio(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ServiciosPorInmueble>> ObtenerServiciosPorInmueble()
        {
            return await _dbContext.ServiciosPorInmuebles.ToListAsync();
        }

        public async Task<int> InsertarServicioPorInmueble(ServiciosPorInmueble servicioPorInmueble)
        {
            if (servicioPorInmueble != null)
            {
                _dbContext.ServiciosPorInmuebles.Add(servicioPorInmueble);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }
    }
}
