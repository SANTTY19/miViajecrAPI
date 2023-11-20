using api_miviajecr.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioInmueble
{
    public class UbicacionInmuebleRepositorio : IUbicacionInmuebleRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public UbicacionInmuebleRepositorio(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UbicacionInmueble> ObtenerUbicacionInmueble()
        {
            return await _dbContext.UbicacionInmuebles.FirstOrDefaultAsync();
        }

        public async Task<int> InsertarUbicacionInmueble(UbicacionInmueble ubicacionInmueble)
        {
            if (ubicacionInmueble != null)
            {
                _dbContext.UbicacionInmuebles.Add(ubicacionInmueble);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }
    }
}
