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
    public class TipoInmuebleController : ControllerBase
    {
        private readonly ITipoInmuebleRepositorio _tipoInmuebleRepositorio;

        public TipoInmuebleController(ITipoInmuebleRepositorio tipoInmuebleRepositorio)
        {
            _tipoInmuebleRepositorio = tipoInmuebleRepositorio;
        }

        [HttpGet("obtenerTiposInmuebles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerTiposInmuebles()
        {
            try
            {
                var tiposInmuebles = await _tipoInmuebleRepositorio.ObtenerTiposInmuebles();

                if (tiposInmuebles != null && tiposInmuebles.Count > 0)
                {
                    return Ok(tiposInmuebles);
                }
                else
                {
                    return NotFound("No se encontraron tipos de inmuebles.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

        [HttpPost("insertarTipoInmueble")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertarTipoInmueble([FromBody] TipoInmueble tipoInmueble)
        {
            try
            {
                if (tipoInmueble == null)
                {
                    return BadRequest("El tipo de inmueble proporcionado es nulo.");
                }

                var resultado = await _tipoInmuebleRepositorio.InsertarTipoInmueble(tipoInmueble);

                if (resultado > 0)
                {
                    return CreatedAtAction("InsertarTipoInmueble", new { id = tipoInmueble.IdTipoInmueble }, tipoInmueble);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error al insertar el tipo de inmueble.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }
    }
}
