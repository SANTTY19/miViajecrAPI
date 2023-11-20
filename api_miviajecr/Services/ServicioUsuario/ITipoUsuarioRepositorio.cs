using System.Collections.Generic;
using System.Threading.Tasks;
using api_miviajecr.Models;

namespace api_miviajecr.Services.ServicioUsuario
{
    public interface ITipoUsuarioRepositorio
    {
        Task<List<TipoUsuario>> ObtenerTiposUsuarios();
        Task<int> InsertarTipoUsuario(TipoUsuario tipoUsuario);
    }
}
