using api_miviajecr.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioInmueble
{
    public class CaracteristicasInmuebleRepositorio : ICaracteristicasInmuebleRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public CaracteristicasInmuebleRepositorio(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CaracteristicasInmueble>> ObtenerCaracteristicasInmueble()
        {
            return await _dbContext.CaracteristicasInmuebles.ToListAsync();
        }

        public async Task<int> InsertarCaracteristicaInmueble(CaracteristicasInmueble caracteristicaInmueble)
        {
            if (caracteristicaInmueble != null)
            {
                _dbContext.CaracteristicasInmuebles.Add(caracteristicaInmueble);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }
    }
}
