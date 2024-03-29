﻿using api_miviajecr.Models;
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
        
        public async Task<List<InmueblesCards>> ObtenerInmueblesCards()
        {
            // Ejecutar el stored procedure y mapear los resultados a la clase InmueblesCustom
            var resultado = await _dbContext.InmueblesCards.FromSqlRaw("EXEC ObtenerInformacionGeneralInmuebles").ToListAsync();

            return resultado;
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

        public async Task<List<InmueblesCustom>> ObtenerInmueblesFavoritos(int inmuebleId)
        {
            return await _dbContext.InmueblesCustom
               .FromSqlRaw<InmueblesCustom>("ObtenerDetallesInmuebleFavoritos {0}", inmuebleId)
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

        public async Task<string> VerificaCuponDescuento(int idInmueble, string cuponDescuento)
        {
            string response = string.Empty;
            try
            {
                string sql = @"exec [spVerificaCuponDescuento] 
                                @IdInmueble,
                                @CuponDescuento,
                                @DbRespuesta OUTPUT";
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@IdInmueble", Value=idInmueble},
                    new SqlParameter { ParameterName = "@CuponDescuento", Value=cuponDescuento},
                    new SqlParameter { ParameterName = "@DbRespuesta", SqlDbType = System.Data.SqlDbType.VarChar, Size = 100, Direction = System.Data.ParameterDirection.Output}
                };

                var affectedRows = _dbContext.Database.ExecuteSqlRaw(sql, parms.ToArray());
                if (parms[2].Value != DBNull.Value)
                {
                    response = parms[2].Value.ToString();
                }
            }
            catch (Exception e)
            {
                response = e.Message;
            }
            return response;
        }

        public async Task<string> InsertarDescuentoPorInmueble(Descuentos descuento)
        {
            string response = string.Empty;
            try
            {
                string sql = @"exec [spInsertaDescuentoInmueble]
                                @IdInmueble,                              
                                @CodigoDescuento,
                                @MontoDescuento";

                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@IdInmueble", Value=descuento.IdInmueble},
                    new SqlParameter { ParameterName = "@CodigoDescuento", Value=descuento.CodigoDescuento},
                    new SqlParameter { ParameterName = "@MontoDescuento", Value=descuento.MontoDescuento}
                    
                };

                var affectedRows = _dbContext.Database.ExecuteSqlRaw(sql, parms.ToArray());
                if (affectedRows > 0)
                {
                    response = "Cupon insertado correctamente.";
                }
            }
            catch (Exception e)
            {
                response = e.Message;
            }
            return response;
        }
    }
}
