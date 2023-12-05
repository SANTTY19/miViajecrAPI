using System.Collections.Generic;
using System.Threading.Tasks;
using api_miviajecr.Models;

namespace api_miviajecr.Services.ServicioAmenidades
{
    public interface IAmenidadRepositorio
    {
        Task<List<Amenidade>> ObtenerAmenidades();
        Task<int> InsertarAmenidad(Amenidade amenidad);
        Task<int> ModificarAmenidad(Amenidade amenidad);

    }
}