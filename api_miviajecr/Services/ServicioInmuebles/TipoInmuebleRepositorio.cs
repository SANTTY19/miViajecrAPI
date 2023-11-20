using api_miviajecr.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioInmueble
{
    public class TipoInmuebleRepositorio : ITipoInmuebleRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public TipoInmuebleRepositorio(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TipoInmueble>> ObtenerTiposInmuebles()
        {
            return await _dbContext.TipoInmuebles.ToListAsync();
        }

        public async Task<int> InsertarTipoInmueble(TipoInmueble tipoInmueble)
        {
            if (tipoInmueble != null)
            {
                _dbContext.TipoInmuebles.Add(tipoInmueble);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }
    }
}
