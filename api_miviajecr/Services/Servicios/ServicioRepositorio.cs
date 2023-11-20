using api_miviajecr.Models;
using api_miviajecr.Services.Servicios;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioInmueble
{
    public class ServicioRepositorio : IServicioRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public ServicioRepositorio(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Servicio>> ObtenerServicios()
        {
            return await _dbContext.Servicios.ToListAsync();
        }

        public async Task<int> InsertarServicio(Servicio servicio)
        {
            if (servicio != null)
            {
                _dbContext.Servicios.Add(servicio);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }
    }
}