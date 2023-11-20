using System.Collections.Generic;
using System.Threading.Tasks;
using api_miviajecr.Models;

namespace api_miviajecr.Services.ServicioUsuario
{
    public interface ICalificacionUsuarioRepositorio
    {
        Task<List<CalificacionUsuario>> ObtenerCalificacionesUsuarios();
        Task<int> InsertarCalificacionUsuario(CalificacionUsuario calificacionUsuario);
        
    }
}