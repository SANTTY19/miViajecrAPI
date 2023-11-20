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
    public class InmuebleController : ControllerBase
    {
        private readonly IInmuebleRepositorio _inmuebleRepositorio;

        public InmuebleController(IInmuebleRepositorio inmuebleRepositorio)
        {
            _inmuebleRepositorio = inmuebleRepositorio;
        }

        [HttpGet("obtenerInmuebles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerInmuebles()
        {
            try
            {
                var inmuebles = await _inmuebleRepositorio.ObtenerInmuebles();

                if (inmuebles != null && inmuebles.Count > 0)
                {
                    return Ok(inmuebles);
                }
                else
                {
                    return NotFound("No se encontraron inmuebles.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

        [HttpPost("insertarInmueble")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertarInmueble([FromBody] Inmueble inmueble)
        {
            try
            {
                if (inmueble == null)
                {
                    return BadRequest("El inmueble proporcionado es nulo.");
                }

                var resultado = await _inmuebleRepositorio.InsertarInmueble(inmueble);

                if (resultado > 0)
                {
                    return CreatedAtAction("InsertarInmueble", new { id = inmueble.IdInmueble }, inmueble);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error al insertar el inmueble.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

        [HttpGet("obtenerInmueblesFavoritos/{idInmueble}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerInmueblesFavoritos(int idInmueble)
        {
            try
            {
                var inmuebles = await _inmuebleRepositorio.ObtenerInmueblesFavoritos(idInmueble);

                if (inmuebles != null && inmuebles.Count > 0)
                {
                    return Ok(inmuebles);
                }
                else
                {
                    return NotFound("No se encontraron inmuebles.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

        [HttpPost("agregarInmuebleAFavoritos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AgregarInmuebleAFavoritos(int idUsuario, int idInmueble)
        {
            if (idUsuario <= 0 || idInmueble <= 0)
            {
                return BadRequest();
            }

            return Ok(await _inmuebleRepositorio.AgregarInmuebleAFavoritos(idUsuario, idInmueble));
        }
    }
}
