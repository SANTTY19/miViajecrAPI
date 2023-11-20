using api_miviajecr.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioFavoritos
{
    public class FavoritoRepositorio : IFavoritoRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public FavoritoRepositorio(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Favorito>> ObtenerFavoritos()
        {
            return await _dbContext.Favoritos.ToListAsync();
        }
    }
}
