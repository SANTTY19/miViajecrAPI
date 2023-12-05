using api_miviajecr.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioPoliticas
{
    public interface IPoliticaRepositorio
    {
        Task<List<Politica>> ObtenerPoliticas();
        Task<int> InsertarPolitica(Politica politica);
        Task<int> ModificarPolitica(Politica politica);

    }
}