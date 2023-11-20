using api_miviajecr.Models;
using api_miviajecr.Services.ServicioUsuario;  
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_miviajecr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalificacionUsuarioController : ControllerBase
    {
        private readonly ICalificacionUsuarioRepositorio _calificacionUsuarioRepositorio;

        public CalificacionUsuarioController(ICalificacionUsuarioRepositorio calificacionUsuarioRepositorio)
        {
            _calificacionUsuarioRepositorio = calificacionUsuarioRepositorio;
        }

        [HttpGet("obtenerCalificacionesUsuarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerCalificacionesUsuarios()
        {
            try
            {
                var calificacionesUsuarios = await _calificacionUsuarioRepositorio.ObtenerCalificacionesUsuarios();

                if (calificacionesUsuarios != null && calificacionesUsuarios.Any())
                {
                    return Ok(calificacionesUsuarios);
                }
                else
                {
                    return NotFound("No se encontraron calificaciones de usuarios.");
                }
            }
            catch (Exception ex)
            {
               
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

        [HttpPost("insertarCalificacionUsuario")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertarCalificacionUsuario([FromBody] CalificacionUsuario calificacionUsuario)
        {
            try
            {
                if (calificacionUsuario == null)
                {
                    return BadRequest("La calificación de usuario proporcionada es nula.");
                }

                var resultado = await _calificacionUsuarioRepositorio.InsertarCalificacionUsuario(calificacionUsuario);

                if (resultado > 0)
                {
                    return CreatedAtAction("InsertarCalificacionUsuario", new { id = calificacionUsuario.IdCalificacionUsuario }, calificacionUsuario);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error al insertar la calificación de usuario.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

    }
}