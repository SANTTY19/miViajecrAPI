using api_miviajecr.Models;
using api_miviajecr.Services.ServicioInmueble;
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
    public class ServiciosPorInmuebleController : ControllerBase
    {
        private readonly IServiciosPorInmuebleRepositorio _serviciosPorInmuebleRepositorio;

        public ServiciosPorInmuebleController(IServiciosPorInmuebleRepositorio serviciosPorInmuebleRepositorio)
        {
            _serviciosPorInmuebleRepositorio = serviciosPorInmuebleRepositorio;
        }

        [HttpGet("obtenerServiciosPorInmueble")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerServiciosPorInmueble(int idInmueble)
        {
            try
            {
                var serviciosPorInmueble = await _serviciosPorInmuebleRepositorio.ObtenerServiciosPorInmueble();

                if (serviciosPorInmueble != null && serviciosPorInmueble.Any())
                {
                    return Ok(serviciosPorInmueble);
                }
                else
                {
                    return NotFound("No se encontraron servicios para el inmueble.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

        [HttpPost("insertarServicioPorInmueble")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertarServicioPorInmueble([FromBody] ServiciosPorInmueble servicioPorInmueble)
        {
            if (servicioPorInmueble == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await _serviciosPorInmuebleRepositorio.InsertarServicioPorInmueble(servicioPorInmueble);

                if (result > 0)
                {
                    return Ok("Servicio por inmueble insertado correctamente.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error al insertar el servicio por inmueble.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }
    }
}
