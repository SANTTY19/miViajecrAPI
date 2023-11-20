using api_miviajecr.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_miviajecr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public TipoUsuarioController(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("obtenerTiposUsuarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerTiposUsuarios()
        {
            try
            {
                var tiposUsuarios = await _dbContext.TipoUsuarios.ToListAsync();

                if (tiposUsuarios != null && tiposUsuarios.Any())
                {
                    return Ok(tiposUsuarios);
                }
                else
                {
                    return NotFound("No se encontraron tipos de usuarios.");
                }
            }
            catch (Exception ex)
            {
                // Loguea el error o realiza cualquier otra acción necesaria.
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

        [HttpPost("registrarTipoUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegistrarTipoUsuario([FromBody] TipoUsuario tipoUsuario)
        {
            if (tipoUsuario == null)
            {
                return BadRequest();
            }

            try
            {
                tipoUsuario.FechaCreacion = DateTime.Now;
                tipoUsuario.EstaActivo = true;

                _dbContext.TipoUsuarios.Add(tipoUsuario);
                await _dbContext.SaveChangesAsync();

                return Ok(tipoUsuario);
            }
            catch (Exception ex)
            {
                // Loguea el error o realiza cualquier otra acción necesaria.
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

    }
}
