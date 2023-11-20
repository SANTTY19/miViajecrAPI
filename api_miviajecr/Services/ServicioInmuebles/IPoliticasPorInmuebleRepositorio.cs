using api_miviajecr.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioPoliticas
{
    public interface IPoliticasPorInmuebleRepositorio
    {
        Task<List<PoliticasPorInmueble>> ObtenerPoliticasPorInmueble();
        Task<int> InsertarPoliticaPorInmueble(PoliticasPorInmueble politicaPorInmueble);
    }
}
