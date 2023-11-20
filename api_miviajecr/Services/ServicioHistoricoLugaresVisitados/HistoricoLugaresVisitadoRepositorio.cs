using api_miviajecr.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioHistoricoLugaresVisitado
{
    public class HistoricoLugaresVisitadoRepositorio : IHistoricoLugaresVisitadoRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public HistoricoLugaresVisitadoRepositorio(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<HistoricoLugaresVisitado>> ObtenerHistoricoLugaresVisitados()
        {
            return await _dbContext.HistoricoLugaresVisitados.ToListAsync();
        }
    }
}
