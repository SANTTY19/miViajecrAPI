using api_miviajecr.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace api_miviajecr.Services.ServicioDenuncias
{
    public class DenunciaRepositorio : IDenunciaRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public DenunciaRepositorio(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Denuncia>> ObtenerDenuncias()
        {
            return await _dbContext.Denuncias.ToListAsync();
        }

        public async Task<int> InsertarDenuncia(Denuncia denuncia)
        {
            if (denuncia != null)
            {
                _dbContext.Denuncias.Add(denuncia);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return -1; 
            }
        }
    }
}
