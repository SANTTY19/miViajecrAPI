using api_miviajecr.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioUsuario
{//Este metodo como tal va hacer la inserccion del usuario,se conecta con los datos:aqui se ejecuta los store procedures,se conecta a la base de datos
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public UsuarioRepositorio(tiusr27pl_ApimisviajescrContext context)
        {
            _dbContext = context;
            
        }
        public async Task<int> InsertaUsuario(Usuario usuario)
        {
            if (usuario != null)
            {
                // Establecer propiedades del usuario manualmente (simplificado)
                usuario.FechaCreacion = DateTime.Now;
                usuario.EstaActivo = true;

                // Establecer valores predeterminados
                usuario.FotoIdentificacion = " ";
                usuario.PromedioCalificacion = 5;
                usuario.SesionActiva = true;
                usuario.Token = "Token01";
                usuario.EstaActivo = true;
                usuario.FueValidado = true;

                // Puedes ajustar aquí para incluir solo los campos que deseas
                var perfilSimplificado = new
                {
                    usuario.IdUsuario,
                    usuario.IdTipoUsuario,
                    usuario.Nombre,
                    usuario.Apellidos,
                    usuario.FechaNacimiento,
                    usuario.CorreoElectronico,
                    usuario.NumeroTelefono,
                    usuario.Contraseña,
                    usuario.FotoIdentificacion,
                    usuario.PromedioCalificacion,
                    usuario.SesionActiva,
                    usuario.Token,
                    usuario.EstaActivo,
                    usuario.FueValidado,
                    usuario.FechaCreacion
                };

                _dbContext.Usuarios.Add(usuario);
               return await _dbContext.SaveChangesAsync();

                //return Results.Created($"/PerfilesUsuarios/{usuario.IdUsuario}", perfilSimplificado);
            }
            else
            {
                return -1;
            }
            
        }

        public async Task<List<Usuario>> ObtenerUsuarios()
        {
            try
            {
                var usuarios = await _dbContext.Usuarios.ToListAsync();
                return usuarios;
            }
            catch (Exception ex)
            {
                // Loguea el error o realiza cualquier otra acción necesaria.
                return null;
            }
        }



    }
}
