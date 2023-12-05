using api_miviajecr.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioPoliticas
{
    public class PoliticaRepositorio : IPoliticaRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public PoliticaRepositorio(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Politica>> ObtenerPoliticas()
        {
            return await _dbContext.Politicas.ToListAsync();
        }

        public async Task<int> InsertarPolitica(Politica politica)
        {
            if (politica != null)
            {
                _dbContext.Politicas.Add(politica);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }
        public async Task<int> ModificarPolitica(Politica politica)
        {
            try
            {
                var politicaExistente = await _dbContext.Politicas.FindAsync(politica.IdPolitica);

                if (politicaExistente != null)
                {
                    politicaExistente.Descripcion = politica.Descripcion;
                    politicaExistente.EstaActivo = politica.EstaActivo;
                    politicaExistente.FechaCreacion = politica.FechaCreacion;
                    politicaExistente.IconUrl = politica.IconUrl;

                    _dbContext.Politicas.Update(politicaExistente);
                    return await _dbContext.SaveChangesAsync();
                }
                else
                {
                    return -1; // O un código que indique que no se encontró la política
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