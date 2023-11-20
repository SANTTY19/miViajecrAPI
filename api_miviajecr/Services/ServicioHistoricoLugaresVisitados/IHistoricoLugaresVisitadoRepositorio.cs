using api_miviajecr.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioHistoricoLugaresVisitado
{
    public interface IHistoricoLugaresVisitadoRepositorio
    {
        Task<List<HistoricoLugaresVisitado>> ObtenerHistoricoLugaresVisitados();
    }
}
