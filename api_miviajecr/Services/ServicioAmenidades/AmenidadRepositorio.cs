using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_miviajecr.Models;
using Microsoft.EntityFrameworkCore;

namespace api_miviajecr.Services.ServicioAmenidades
{
    public class AmenidadRepositorio : IAmenidadRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public AmenidadRepositorio(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Amenidade>> ObtenerAmenidades()
        {
            return await _dbContext.Amenidades
                .ToListAsync();
        }

        public async Task<int> InsertarAmenidad(Amenidade amenidad)
        {
            if (amenidad != null)
            {
                _dbContext.Amenidades.Add(amenidad);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }
    }
}