using api_miviajecr.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioInmueble
{
    public class InmuebleRepositorio : IInmuebleRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public InmuebleRepositorio(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Inmueble>> ObtenerInmuebles()
        {
            return await _dbContext.Inmuebles.ToListAsync();
        }

        public async Task<int> InsertarInmueble(Inmueble inmueble)
        {
            if (inmueble != null)
            {
                // Puedes ajustar aquí para incluir solo los campos que deseas
                var inmuebleSimplificado = new
                {
                    inmueble.IdInmueble,
                    inmueble.IdUsuario,
                    inmueble.IdTipoInmueble,
                    inmueble.TituloInmueble,
                    inmueble.DescripcionInmuebles,
                    inmueble.PrecioPorNoche,
                    inmueble.PromedioCalificacion,
                    inmueble.EstaActivo,
                    inmueble.FechaCreacion
                };

                _dbContext.Inmuebles.Add(inmueble);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }

        public async Task<List<InmueblesCustom>> ObtenerInmueblesFavoritos(int idUsuario)
        {
            return await _dbContext.InmueblesCustom
               .FromSqlRaw<InmueblesCustom>("ObtenerDetallesInmuebleFavoritos {0}", idUsuario)
               .ToListAsync();

        }
        public async Task<string> AgregarInmuebleAFavoritos(int idUsuario, int idInmueble)
        {
            string response = string.Empty;
            try
            {
                string sql = @"exec [viajescr].[AgregarInmuebleFavorito] 
                                @IdUsuario,                              
                                @IdInmueble";

                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@IdUsuario", Value = idUsuario },
                    new SqlParameter { ParameterName = "@IdInmueble", Value = idInmueble }
                };

                _dbContext.Database.ExecuteSqlRaw(sql, parms.ToArray());
                response = "Inmueble agregado a favoritos correctamente.";
            }
            catch (Exception e)
            {
                response = e.Message;
            }
            return response;
        }
    }
}
