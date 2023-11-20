using api_miviajecr.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioInmuebles
{
    public class Detalle : IDetalle
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public Detalle(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DetalleInmueble>> ObtenerInformacionInmuebles()
        {
            return await _dbContext.DetalleInmuebles.FromSqlRaw<DetalleInmueble>("ObtenerInformacionInmuebles").ToListAsync();
        }

    }
}
