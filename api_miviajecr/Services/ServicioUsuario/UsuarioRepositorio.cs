﻿using api_miviajecr.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioUsuario
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public UsuarioRepositorio(tiusr27pl_ApimisviajescrContext context)
        {
            _dbContext = context;
            
        }

        public async Task<string> InsertaUsuario(int idTipoUsuario, string nombre, string apellidos, DateTime fechaNacimiento, string numeroTelefono, string fotoIdentificacion, string correoElectronico, string contraseña)
        {
            string response = string.Empty;
            try
            {
                string sql = @"exec [spInsertaUsuario] 
                                @IdTipoUsuario,
                                @Nombre,                              
                                @Apellidos,
                                @FechaNacimiento,
                                @CorreoElectronico,   
                                @NumeroTelefono,                        
                                @Contraseña,
                                @FotoIdentificacion,
                                @DbRespuesta OUTPUT";

                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@IdTipoUsuario", Value=idTipoUsuario},
                    new SqlParameter { ParameterName = "@Nombre", Value=nombre},
                    new SqlParameter { ParameterName = "@Apellidos", Value=apellidos},
                    new SqlParameter { ParameterName = "@FechaNacimiento", Value=fechaNacimiento},
                    new SqlParameter { ParameterName = "@CorreoElectronico", Value=correoElectronico},
                    new SqlParameter { ParameterName = "@NumeroTelefono", Value=numeroTelefono},
                    new SqlParameter { ParameterName = "@Contraseña", Value=contraseña},
                    new SqlParameter { ParameterName = "@FotoIdentificacion", Value=fotoIdentificacion},
                    new SqlParameter { ParameterName = "@DbRespuesta", SqlDbType = System.Data.SqlDbType.VarChar, Size = 100, Direction = System.Data.ParameterDirection.Output}
                };

                var affectedRows = _dbContext.Database.ExecuteSqlRaw(sql, parms.ToArray());
                if (parms[8].Value != DBNull.Value)
                {
                    response = parms[8].Value.ToString();
                }
            }
            catch (Exception e)
            {
                response = e.Message;
            }
            return response;
        }

        public async Task<string> LoginUsuario(string correoElectronico, string contraseña)
        {
            string response = string.Empty;
            try
            {
                string sql = @"exec [spLogin] 
                                @CorreoElectronico,                              
                                @Contraseña,
                                @DbRespuesta OUTPUT";

                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@CorreoElectronico", Value=correoElectronico},
                    new SqlParameter { ParameterName = "@Contraseña", Value=contraseña},
                    new SqlParameter { ParameterName = "@DbRespuesta", SqlDbType = System.Data.SqlDbType.VarChar, Size = 1000, Direction = System.Data.ParameterDirection.Output}
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

        public async Task<string> LogoutUsuario(int idUsuario)
        {
            string response = string.Empty;
            try
            {
                string sql = @"exec [spLogout] 
                                @IdUsuario,
                                @DbRespuesta OUTPUT";

                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@IdUsuario", Value=idUsuario},
                    new SqlParameter { ParameterName = "@DbRespuesta", SqlDbType = System.Data.SqlDbType.VarChar, Size = 100, Direction = System.Data.ParameterDirection.Output}
                };

                var affectedRows = _dbContext.Database.ExecuteSqlRaw(sql, parms.ToArray());
                if (parms[1].Value != DBNull.Value)
                {
                    response = parms[1].Value.ToString();
                }

            }
            catch (Exception e)
            {
                response = e.Message;
            }
            return response;
        }

        public async Task<string> ObtieneTokenPorIdUsuario(int idUsuario)
        {
            try
            {
                string sql = @"exec [spObtieneToken] 
                                @IdUsuario,
                                @DbRespuesta OUTPUT";
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@IdUsuario", Value=idUsuario},
                    new SqlParameter { ParameterName = "@DbRespuesta", SqlDbType = System.Data.SqlDbType.VarChar, Size = 100, Direction = System.Data.ParameterDirection.Output}
                };

                var affectedRows = _dbContext.Database.ExecuteSqlRaw(sql, parms.ToArray());
                if (parms[1].Value != DBNull.Value)
                {
                    var jsonResult = new
                    {
                        token = parms[1].Value
                    };
                    return JsonConvert.SerializeObject(jsonResult);
                }
                else
                {
                    var jsonResult = new
                    {
                        token = ""
                    };
                    return JsonConvert.SerializeObject(jsonResult);
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<List<PlantillasNotificacionPorCorreo>> ObtienePlantillaPorTipoNotificacion(int idTipoNotificacion)
        {            
            return await _dbContext.PlantillasNotificacionPorCorreo
                    .FromSqlRaw<PlantillasNotificacionPorCorreo>("spObtienePlantillaPorTipoNotificacion {0}", idTipoNotificacion)
                    .ToListAsync();
        }

        public async Task<List<CorreoElectronicoConfig>> ObtieneCuentasAdminCorreo()
        {
            return await _dbContext.CorreoElectronicoConfig
                    .FromSqlRaw<CorreoElectronicoConfig>("spObtieneCuentasAdminCorreos")
                    .ToListAsync();
        }

        public async Task<List<PlantillasNotificacionPorCorreo>> ObtienePlantillasNotificaciones()
        {
            return await _dbContext.PlantillasNotificacionPorCorreo
                    .FromSqlRaw<PlantillasNotificacionPorCorreo>("spObtienePlantillasNotificaciones")
                    .ToListAsync();
        }

        public async Task<string> InsertaPlantilla(int idPlantilla, string plantillaHtml, string sujetoPlantilla, string tituloPlantilla, string cuerpoPlantilla, string pieDePaginaPlantilla)
        {
            string response = string.Empty;
            try
            {
                string sql = @"exec [spInsertaPlantillasNotificaciones] 
                                @IdPlantilla,
                                @PlantillaHtml,                              
                                @SujetoPlantilla,
                                @TituloPlantilla,
                                @CuerpoPlantilla,   
                                @PieDePaginaPlantilla,
                                @DbRespuesta OUTPUT";

                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter { ParameterName = "@IdPlantilla", Value=idPlantilla},
                    new SqlParameter { ParameterName = "@PlantillaHtml", Value=plantillaHtml},
                    new SqlParameter { ParameterName = "@SujetoPlantilla", Value=sujetoPlantilla},
                    new SqlParameter { ParameterName = "@TituloPlantilla", Value=tituloPlantilla},
                    new SqlParameter { ParameterName = "@CuerpoPlantilla", Value=cuerpoPlantilla},
                    new SqlParameter { ParameterName = "@PieDePaginaPlantilla", Value=pieDePaginaPlantilla},
                    new SqlParameter { ParameterName = "@DbRespuesta", SqlDbType = System.Data.SqlDbType.VarChar, Size = 100, Direction = System.Data.ParameterDirection.Output}
                };

                var affectedRows = _dbContext.Database.ExecuteSqlRaw(sql, parms.ToArray());
                if (parms[6].Value != DBNull.Value)
                {
                    response = parms[6].Value.ToString();
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
