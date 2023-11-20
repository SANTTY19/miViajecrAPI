using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api_miviajecr.Models;
using Microsoft.EntityFrameworkCore;

namespace api_miviajecr.Services.ServicioUsuario
{
    public class CalificacionUsuarioRepositorio : ICalificacionUsuarioRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public CalificacionUsuarioRepositorio(tiusr27pl_ApimisviajescrContext context)
        {
            _dbContext = context;
        }

        public async Task<List<CalificacionUsuario>> ObtenerCalificacionesUsuarios()
        {
            try
            {
                var calificacionesUsuarios = await _dbContext.CalificacionUsuarios.ToListAsync();
                return calificacionesUsuarios;
            }
            catch (Exception ex)
            {
                // Loguea el error o realiza cualquier otra acción necesaria.
                return null;
            }
        }

        public async Task<int> InsertarCalificacionUsuario(CalificacionUsuario calificacionUsuario)
        {
            if (calificacionUsuario != null)
            {
                calificacionUsuario.FechaCreacion = DateTime.Now;

                _dbContext.CalificacionUsuarios.Add(calificacionUsuario);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }
    }
}