using api_miviajecr.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioInmueble
{
    public class ImagenesInmuebleRepositorio : IImagenesInmuebleRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public ImagenesInmuebleRepositorio(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ImagenesInmueble>> ObtenerImagenesInmueble()
        {
            return await _dbContext.ImagenesInmuebles.ToListAsync();
        }

        public async Task<int> InsertarImagenInmueble(ImagenesInmueble imagenInmueble)
        {
            if (imagenInmueble != null)
            {
                _dbContext.ImagenesInmuebles.Add(imagenInmueble);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }
    }
}