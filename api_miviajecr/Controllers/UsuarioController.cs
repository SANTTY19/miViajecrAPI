using api_miviajecr.Models;
using api_miviajecr.Services.ServicioUsuario;
using MiBancoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Controllers
{
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;
        EmailHelper _emailHelper;

        public UsuarioController(tiusr27pl_ApimisviajescrContext dbContext, IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _dbContext = dbContext;
            _emailHelper = new EmailHelper(_dbContext, _usuarioRepositorio);
        }

        [HttpPost("api/registrarUsuario")]
        public async Task<IActionResult> RegistrarUsuario(int idTipoUsuario, string nombre, string apellidos, DateTime fechaNacimiento, string numeroTelefono, string fotoIdentificacion, string correoElectronico, string contraseña)
        {
            if (idTipoUsuario == null|| String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(apellidos) || fechaNacimiento == null || String.IsNullOrEmpty(correoElectronico) || String.IsNullOrEmpty(contraseña) || String.IsNullOrEmpty(numeroTelefono))
            {
                return BadRequest();
            }

            return Ok(await _usuarioRepositorio.InsertaUsuario(idTipoUsuario, nombre, apellidos, fechaNacimiento, numeroTelefono, fotoIdentificacion, correoElectronico, contraseña));
        }

        [HttpPost("api/login")]
        public async Task<IActionResult> Login(string correoElectronico, string contraseña)
        {
            if (String.IsNullOrEmpty(correoElectronico) || String.IsNullOrEmpty(contraseña))
            {
                return BadRequest();
            }

            string result = await _usuarioRepositorio.LoginUsuario(correoElectronico, contraseña);
            if (result.Contains("IdUsuario"))
            {
                string[] splitResponse = result.Split(':');
                string jsonResponse = await _usuarioRepositorio.ObtieneTokenPorIdUsuario(Convert.ToInt32(splitResponse[1]));
                dynamic data = JObject.Parse(jsonResponse);
                string dbToken = data.token;

                //_emailHelper.EnviarCorreoElectronico(correoElectronico, "miViajeCR | Codigo de verificación", "Tu código es: \n " + dbToken);
                await _emailHelper.EnviarCorreoElectronico(1, correoElectronico, dbToken);
            }

            return Ok(result);
        }

        [HttpPost("api/logout")]
        public async Task<IActionResult> Logout(int idUsuario)
        {
            if (idUsuario == null)
            {
                return BadRequest();
            }

            return Ok(await _usuarioRepositorio.LogoutUsuario(idUsuario));
        }

        [HttpPost("api/validarToken")]
        public async Task<IActionResult> ValidarToken(int idUsuario, string token)
        {
            if (String.IsNullOrEmpty(token) || idUsuario == null)
            {
                return BadRequest();
            }

            string result = await _usuarioRepositorio.ObtieneTokenPorIdUsuario(idUsuario);
            dynamic data = JObject.Parse(result);
            string dbToken = data.token;
            if (dbToken.ToLower() == token.ToLower())
            {                                
                return Ok("Token confirmado.");
            }
            else
            {
                return Ok("Los token no coinciden.");
            }
        }
        [HttpGet("api/usuarios")] // Ruta para obtener todos los usuarios
        public async Task<IActionResult> ObtenerUsuarios()
        {
            try
            {
                // Lógica para obtener la lista de usuarios desde tu repositorio
                List<Usuario> usuarios = await _usuarioRepositorio.ObtenerUsuarios(); // Asume que tienes un método en tu repositorio para obtener usuarios

                if (usuarios != null && usuarios.Count > 0)
                {
                    return Ok(usuarios); // Devuelve la lista de usuarios en formato JSON si se encontraron usuarios
                }
                else
                {
                    return NotFound("No se encontraron usuarios"); // Si no se encuentran usuarios
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener usuarios: {ex.Message}"); // En caso de error interno del servidor
            }
        }

        [HttpGet("api/obtenerCuentasAdmin")]
        public async Task<IActionResult> ObtieneCuentasAdminCorreo()
        {
            try
            {
                var cuentas = await _usuarioRepositorio.ObtieneCuentasAdminCorreo();

                if (cuentas != null && cuentas.Count > 0)
                {
                    return Ok(cuentas);
                }
                else
                {
                    return NotFound("No se encontraron cuentas.");
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("api/obtenerPlantillasNotificaciones")]
        public async Task<IActionResult> ObtienePlantillasNotificaciones()
        {
            try
            {
                var plantillas = await _usuarioRepositorio.ObtienePlantillasNotificaciones();

                if (plantillas != null && plantillas.Count > 0)
                {
                    return Ok(plantillas);
                }
                else
                {
                    return NotFound("No se encontraron plantillas.");
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost("api/insertaPlantilla")]
        public async Task<IActionResult> InsertaPlantilla(string plantillaHtml, string sujetoPlantilla, string tituloPlantilla, string cuerpoPlantilla, string pieDePaginaPlantilla)
        {
            if (plantillaHtml == null && sujetoPlantilla == null && tituloPlantilla == null && cuerpoPlantilla == null && pieDePaginaPlantilla == null)
            {
                return BadRequest("Revisa los parametros...");
            }           

            return Ok(await _usuarioRepositorio.InsertaPlantilla(plantillaHtml, sujetoPlantilla, tituloPlantilla, cuerpoPlantilla, pieDePaginaPlantilla));
        }

        [HttpGet("api/obtenerInfoUsuarioPorId")]
        public async Task<IActionResult> ObtieneInfoUsuarioPorId(int idUsuario)
        {
            try
            {
                var usuario = await _usuarioRepositorio.ObtieneUsuarioPorId(idUsuario);
                if (usuario != null)
                {
                    return Ok(usuario);
                }
                else
                {
                    return NotFound("Usuario no registrado.");
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("api/verificaCorreoElectronico")]
        public async Task<IActionResult> VerificaCorreoElectronico(string correoElectronico)
        {
            if (correoElectronico == null)
            {
                return BadRequest("Revisa los parametros...");
            }

            return Ok(await _usuarioRepositorio.VerificaCorreoElectronico(correoElectronico));
        }

        [HttpGet("api/obtenerNotificacionesPorIdUsuario")]
        public async Task<IActionResult> ObtieneNotificacionesPorIdUsuario(int idUsuario)
        {
            try
            {
                var notificaciones = await _usuarioRepositorio.ObtieneNotificacionesPorIdUsuario(idUsuario);

                if (notificaciones != null && notificaciones.Count > 0)
                {
                    return Ok(notificaciones);
                }
                else
                {
                    return NotFound("No tiene notificaciones.");
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost("api/insertaNotificacion")]
        public async Task<IActionResult> InsertaNotificacion(int idUsuario, string notificacion)
        {
            if (idUsuario == null && notificacion == null)
            {
                return BadRequest("Revisa los parametros...");
            }

            return Ok(await _usuarioRepositorio.InsertaNotificacionUsuario(idUsuario, notificacion));
        }

        [HttpPut("api/actualizaNotificacion")]
        public async Task<IActionResult> ActualizaNotificacion(int idNotificacion, bool fueLeida)
        {
            if (idNotificacion == null && fueLeida == null)
            {
                return BadRequest("Revisa los parametros...");
            }

            return Ok(await _usuarioRepositorio.ActualizaNotificacion(idNotificacion, fueLeida));
        }
    }
}
