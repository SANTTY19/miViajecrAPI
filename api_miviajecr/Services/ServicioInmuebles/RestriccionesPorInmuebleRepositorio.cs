using api_miviajecr.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioRestricciones
{
    public class RestriccionesPorInmuebleRepositorio : IRestriccionesPorInmuebleRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public RestriccionesPorInmuebleRepositorio(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<RestriccionesPorInmueble>> ObtenerRestriccionesPorInmueble()
        {
            return await _dbContext.RestriccionesPorInmuebles.ToListAsync();
        }

        public async Task<int> InsertarRestriccionPorInmueble(RestriccionesPorInmueble restriccionPorInmueble)
        {
            if (restriccionPorInmueble != null)
            {
                _dbContext.RestriccionesPorInmuebles.Add(restriccionPorInmueble);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }
    }
}
