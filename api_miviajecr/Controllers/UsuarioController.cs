using api_miviajecr.Services.ServicioUsuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using api_miviajecr.Models;
using System.Linq;

namespace api_miviajecr.Controllers
{
   [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpPost("api/registrarUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegistrarUsuario([FromBody] Usuario usuario)
        {
            if (usuario==null)
            {
                return BadRequest();
            }

            return Ok(await _usuarioRepositorio.InsertaUsuario(usuario));
        }

        [HttpGet("api/obtenerUsuarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            try
            {
                var usuarios = await _usuarioRepositorio.ObtenerUsuarios(); // Agrega el await para esperar la tarea.

                if (usuarios != null && usuarios.Any()) // Ahora puedes usar Any() en la lista de usuarios.
                {
                    return Ok(usuarios);
                }
                else
                {
                    return NotFound("No se encontraron usuarios.");
                }
            }
            catch (Exception ex)
            {
                // Loguea el error o realiza cualquier otra acción necesaria.
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }


    }
}
