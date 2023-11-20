using api_miviajecr.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioPoliticas
{
    public class PoliticasPorInmuebleRepositorio : IPoliticasPorInmuebleRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public PoliticasPorInmuebleRepositorio(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PoliticasPorInmueble>> ObtenerPoliticasPorInmueble()
        {
            return await _dbContext.PoliticasPorInmuebles.ToListAsync();
        }

        public async Task<int> InsertarPoliticaPorInmueble(PoliticasPorInmueble politicaPorInmueble)
        {
            if (politicaPorInmueble != null)
            {
                _dbContext.PoliticasPorInmuebles.Add(politicaPorInmueble);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }
    }
}
