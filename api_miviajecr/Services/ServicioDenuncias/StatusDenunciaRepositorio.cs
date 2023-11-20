using api_miviajecr.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioDenuncias
{
    public class StatusDenunciaRepositorio : IStatusDenunciaRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public StatusDenunciaRepositorio(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<StatusDenuncium>> ObtenerEstadosDenuncia()
        {
            return await _dbContext.StatusDenuncia.ToListAsync();
        }
    }
}
