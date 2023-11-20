using api_miviajecr.Models;
using api_miviajecr.Services.ServicioInmueble;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisponibilidadInmuebleController : ControllerBase
    {
        private readonly IDisponibilidadInmuebleRepositorio _disponibilidadInmuebleRepositorio;

        public DisponibilidadInmuebleController(IDisponibilidadInmuebleRepositorio disponibilidadInmuebleRepositorio)
        {
            _disponibilidadInmuebleRepositorio = disponibilidadInmuebleRepositorio;
        }

        [HttpGet("obtenerDisponibilidadInmueble")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerDisponibilidadInmueble()
        {
            try
            {
                var disponibilidadInmueble = await _disponibilidadInmuebleRepositorio.ObtenerDisponibilidadInmueble();

                if (disponibilidadInmueble != null && disponibilidadInmueble.Count > 0)
                {
                    return Ok(disponibilidadInmueble);
                }
                else
                {
                    return NotFound("No se encontró información de disponibilidad de inmuebles.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

        [HttpPost("insertarDisponibilidadInmueble")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertarDisponibilidadInmueble([FromBody] DisponibilidadInmueble disponibilidadInmueble)
        {
            try
            {
                if (disponibilidadInmueble == null)
                {
                    return BadRequest("Los datos de disponibilidad de inmuebles son nulos.");
                }

                var result = await _disponibilidadInmuebleRepositorio.InsertarDisponibilidadInmueble(disponibilidadInmueble);

                if (result > 0)
                {
                    return Ok("Disponibilidad de inmuebles insertada correctamente.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error al insertar disponibilidad de inmuebles.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }
    }
}