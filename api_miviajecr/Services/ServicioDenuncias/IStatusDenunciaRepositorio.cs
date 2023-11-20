using api_miviajecr.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioDenuncias
{
    public interface IStatusDenunciaRepositorio
    {
        Task<List<StatusDenuncium>> ObtenerEstadosDenuncia();
    }
}
