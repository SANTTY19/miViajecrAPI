using api_miviajecr.Models;
using api_miviajecr.Services.ServicioInmueble;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace api_miviajecr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UbicacionInmuebleController : ControllerBase
    {
        private readonly IUbicacionInmuebleRepositorio _ubicacionInmuebleRepositorio;

        public UbicacionInmuebleController(IUbicacionInmuebleRepositorio ubicacionInmuebleRepositorio)
        {
            _ubicacionInmuebleRepositorio = ubicacionInmuebleRepositorio;
        }

        [HttpGet("obtenerUbicacionInmueble")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerUbicacionInmueble(int idInmueble)
        {
            try
            {
                var ubicacionInmueble = await _ubicacionInmuebleRepositorio.ObtenerUbicacionInmueble();

                if (ubicacionInmueble != null)
                {
                    return Ok(ubicacionInmueble);
                }
                else
                {
                    return NotFound("Ubicación del inmueble no encontrada.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

        [HttpPost("insertarUbicacionInmueble")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertarUbicacionInmueble([FromBody] UbicacionInmueble ubicacionInmueble)
        {
            if (ubicacionInmueble == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await _ubicacionInmuebleRepositorio.InsertarUbicacionInmueble(ubicacionInmueble);

                if (result > 0)
                {
                    return Ok("Ubicación del inmueble insertada correctamente.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error al insertar la ubicación del inmueble.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }
    }
}
