using api_miviajecr.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioRestricciones
{
    public class RestriccionesRepositorio : IRestriccionesRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public RestriccionesRepositorio(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Restriccione>> ObtenerRestricciones()
        {
            return await _dbContext.Restricciones
                .Where(r => r.EstaActivo)
                .ToListAsync();
        }

        public async Task<int> InsertarRestriccion(Restriccione restriccion)
        {
            if (restriccion != null)
            {
                _dbContext.Restricciones.Add(restriccion);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }
    }
}
