using api_miviajecr.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_miviajecr.Services.ServicioInmueble;
using api_miviajecr.Services.Servicios;

namespace api_miviajecr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioRepositorio _servicioRepositorio;

        public ServicioController(IServicioRepositorio servicioRepositorio)
        {
            _servicioRepositorio = servicioRepositorio;
        }

        [HttpGet("obtenerServicios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerServicios()
        {
            try
            {
                var servicios = await _servicioRepositorio.ObtenerServicios();

                if (servicios != null && servicios.Any())
                {
                    return Ok(servicios);
                }
                else
                {
                    return NotFound("No se encontraron servicios.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

        [HttpPost("insertarServicio")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertarServicio([FromBody] Servicio servicio)
        {
            try
            {
                if (servicio == null)
                {
                    return BadRequest();
                }

                await _servicioRepositorio.InsertarServicio(servicio);

                return Ok("Servicio insertado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }
        [HttpPut("modificarServicio")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ModificarServicio([FromBody] Servicio servicio)
        {
            if (servicio == null)
            {
                return BadRequest();
            }

            try
            {
                var resultado = await _servicioRepositorio.ModificarServicio(servicio);

                if (resultado > 0)
                {
                    return Ok("Servicio modificado exitosamente.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error al modificar el servicio.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

    }
}