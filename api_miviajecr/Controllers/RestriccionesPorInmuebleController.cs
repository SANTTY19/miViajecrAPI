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
    public class RestriccionesPorInmuebleController : ControllerBase
    {
        private readonly IRestriccionesPorInmuebleRepositorio _restriccionesPorInmuebleRepositorio;

        public RestriccionesPorInmuebleController(IRestriccionesPorInmuebleRepositorio restriccionesPorInmuebleRepositorio)
        {
            _restriccionesPorInmuebleRepositorio = restriccionesPorInmuebleRepositorio;
        }

        [HttpGet("obtenerRestriccionesPorInmueble")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerRestriccionesPorInmueble(int idInmueble)
        {
            try
            {
                var restriccionesPorInmueble = await _restriccionesPorInmuebleRepositorio.ObtenerRestriccionesPorInmueble();

                if (restriccionesPorInmueble != null && restriccionesPorInmueble.Any())
                {
                    return Ok(restriccionesPorInmueble);
                }
                else
                {
                    return NotFound("No se encontraron restricciones para el inmueble.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

        [HttpPost("insertarRestriccionPorInmueble")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertarRestriccionPorInmueble([FromBody] RestriccionesPorInmueble restriccionPorInmueble)
        {
            if (restriccionPorInmueble == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await _restriccionesPorInmuebleRepositorio.InsertarRestriccionPorInmueble(restriccionPorInmueble);

                if (result > 0)
                {
                    return Ok("Restricción por inmueble insertada correctamente.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error al insertar la restricción por inmueble.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }
    }
}
