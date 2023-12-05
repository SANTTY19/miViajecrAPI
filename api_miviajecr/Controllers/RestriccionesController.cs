using api_miviajecr.Models;
using api_miviajecr.Services.ServicioRestricciones;
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
    public class RestriccionesController : ControllerBase
    {
        private readonly IRestriccionesRepositorio _restriccionesRepositorio;

        public RestriccionesController(IRestriccionesRepositorio restriccionesRepositorio)
        {
            _restriccionesRepositorio = restriccionesRepositorio;
        }

        [HttpGet("obtenerRestricciones")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerRestricciones()
        {
            try
            {
                var restricciones = await _restriccionesRepositorio.ObtenerRestricciones();

                if (restricciones != null && restricciones.Any())
                {
                    return Ok(restricciones);
                }
                else
                {
                    return NotFound("No se encontraron restricciones.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

        [HttpPost("insertarRestriccion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertarRestriccion([FromBody] Restriccione restriccion)
        {
            if (restriccion == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await _restriccionesRepositorio.InsertarRestriccion(restriccion);

                if (result > 0)
                {
                    return Ok("Restricción insertada correctamente.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error al insertar la restricción.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }
        [HttpPut("modificarRestriccion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ModificarRestriccion([FromBody] Restriccione restriccion)
        {
            if (restriccion == null)
            {
                return BadRequest();
            }

            try
            {
                var resultado = await _restriccionesRepositorio.ModificarRestriccion(restriccion);

                if (resultado > 0)
                {
                    return Ok("Restricción modificada exitosamente.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error al modificar la restricción.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

    }
}
