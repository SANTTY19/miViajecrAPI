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
    public class AmenidadesPorInmuebleController : ControllerBase
    {
        private readonly IAmenidadesPorInmuebleRepositorio _amenidadesPorInmuebleRepositorio;

        public AmenidadesPorInmuebleController(IAmenidadesPorInmuebleRepositorio amenidadesPorInmuebleRepositorio)
        {
            _amenidadesPorInmuebleRepositorio = amenidadesPorInmuebleRepositorio;
        }

        [HttpGet("obtenerAmenidadesPorInmueble")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerAmenidadesPorInmueble(int idInmueble)
        {
            try
            {
                var amenidadesPorInmueble = await _amenidadesPorInmuebleRepositorio.ObtenerAmenidadesPorInmueble();

                if (amenidadesPorInmueble != null && amenidadesPorInmueble.Any())
                {
                    return Ok(amenidadesPorInmueble);
                }
                else
                {
                    return NotFound("No se encontraron amenidades para el inmueble.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

        [HttpPost("insertarAmenidadPorInmueble")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertarAmenidadPorInmueble([FromBody] AmenidadesPorInmueble amenidadPorInmueble)
        {
            if (amenidadPorInmueble == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await _amenidadesPorInmuebleRepositorio.InsertarAmenidadPorInmueble(amenidadPorInmueble);

                if (result > 0)
                {
                    return Ok("Amenidad por inmueble insertada correctamente.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error al insertar la amenidad por inmueble.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }
    }
}
