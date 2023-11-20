using api_miviajecr.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioRestricciones
{
    public interface IRestriccionesRepositorio
    {
        Task<List<Restriccione>> ObtenerRestricciones();
        Task<int> InsertarRestriccion(Restriccione restriccion);
    }
}
