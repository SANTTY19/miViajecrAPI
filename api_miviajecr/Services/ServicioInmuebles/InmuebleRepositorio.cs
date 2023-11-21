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

        public async Task<string> InsertarInmueble(InmuebleCustom inmueble)
        {
            if (inmueble != null)
            {
                string response = string.Empty;
                try
                {
                    string sql = @"exec [spInsertaInmueble]
                                @IdUsuario,                              
                                @IdTipoInmueble,
                                @Titulo,
                                @Descripcion,                              
                                @PrecioxNoche,
                                @DbRespuesta OUTPUT";

                    List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@IdUsuario", Value=inmueble.IdUsuario},
                    new SqlParameter { ParameterName = "@IdTipoInmueble", Value=inmueble.IdTipoInmueble},
                    new SqlParameter { ParameterName = "@Titulo", Value=inmueble.TituloInmueble},
                    new SqlParameter { ParameterName = "@Descripcion", Value=inmueble.DescripcionInmueble},
                    new SqlParameter { ParameterName = "@PrecioxNoche", Value=inmueble.PrecioPorNoche},
                    new SqlParameter { ParameterName = "@DbRespuesta", SqlDbType = System.Data.SqlDbType.VarChar, Size = 100, Direction = System.Data.ParameterDirection.Output}
                };

                    var affectedRows = _dbContext.Database.ExecuteSqlRaw(sql, parms.ToArray());
                    if (parms[5].Value != DBNull.Value)
                    {
                        response = parms[5].Value.ToString();
                    }

                }
                catch (Exception e)
                {
                    response = e.Message;
                }
                return response;

            }
            else
            {
                return "algo paso";
            }
        }

        public async Task<List<InmueblesCustom>> ObtenerInmueblesFavoritos(int idInmueble)
        {
            return await _dbContext.InmueblesCustom
               .FromSqlRaw<InmueblesCustom>("ObtenerDetallesInmuebleFavoritos {0}", idInmueble)
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
