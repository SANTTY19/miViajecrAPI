using api_miviajecr.Models;
using Microsoft.EntityFrameworkCore;
using System;
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
        public async Task<int> ModificarTipoInmueble(TipoInmueble tipoInmueble)
        {
            try
            {
                var tipoInmuebleExistente = await _dbContext.TipoInmuebles.FindAsync(tipoInmueble.IdTipoInmueble);

                if (tipoInmuebleExistente != null)
                {
                    tipoInmuebleExistente.TipoInmueble1 = tipoInmueble.TipoInmueble1;
                    tipoInmuebleExistente.EstaActivo = tipoInmueble.EstaActivo;
                    tipoInmuebleExistente.FechaCreacion = tipoInmueble.FechaCreacion;
                    tipoInmuebleExistente.IconUrl = tipoInmueble.IconUrl;

                    _dbContext.TipoInmuebles.Update(tipoInmuebleExistente);
                    return await _dbContext.SaveChangesAsync();
                }
                else
                {
                    return -1; // O un código que indique que no se encontró el tipo de inmueble
                }
            }
            catch (Exception)
            {
                // Manejar excepciones si es necesario
                throw; // O retornar un valor específico en caso de error
            }
        }

    }
}
