using api_miviajecr.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioPoliticas
{
    public class PoliticaRepositorio : IPoliticaRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public PoliticaRepositorio(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Politica>> ObtenerPoliticas()
        {
            return await _dbContext.Politicas.ToListAsync();
        }

        public async Task<int> InsertarPolitica(Politica politica)
        {
            if (politica != null)
            {
                _dbContext.Politicas.Add(politica);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }
    }
}