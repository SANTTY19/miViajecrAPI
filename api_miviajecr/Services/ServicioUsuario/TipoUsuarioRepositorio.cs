using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api_miviajecr.Models;
using Microsoft.EntityFrameworkCore;

namespace api_miviajecr.Services.ServicioUsuario
{
    public class TipoUsuarioRepositorio : ITipoUsuarioRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public TipoUsuarioRepositorio(tiusr27pl_ApimisviajescrContext context)
        {
            _dbContext = context;
        }

        public async Task<List<TipoUsuario>> ObtenerTiposUsuarios()
        {
            try
            {
                var tiposUsuarios = await _dbContext.TipoUsuarios.ToListAsync();
                return tiposUsuarios;
            }
            catch (Exception ex)
            {
                // Loguea el error o realiza cualquier otra acción necesaria.
                return null;
            }
        }

        public async Task<int> InsertarTipoUsuario(TipoUsuario tipoUsuario)
        {
            if (tipoUsuario != null)
            {
                tipoUsuario.FechaCreacion = DateTime.Now;
                tipoUsuario.EstaActivo = true;

                _dbContext.TipoUsuarios.Add(tipoUsuario);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }
    }
}
