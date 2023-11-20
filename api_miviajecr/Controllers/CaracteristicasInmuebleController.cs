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
    public class CaracteristicasInmuebleController : ControllerBase
    {
        private readonly ICaracteristicasInmuebleRepositorio _caracteristicasInmuebleRepositorio;

        public CaracteristicasInmuebleController(ICaracteristicasInmuebleRepositorio caracteristicasInmuebleRepositorio)
        {
            _caracteristicasInmuebleRepositorio = caracteristicasInmuebleRepositorio;
        }

        [HttpGet("obtenerCaracteristicasInmueble")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerCaracteristicasInmueble()
        {
            try
            {
                var caracteristicasInmueble = await _caracteristicasInmuebleRepositorio.ObtenerCaracteristicasInmueble();

                if (caracteristicasInmueble != null && caracteristicasInmueble.Count > 0)
                {
                    return Ok(caracteristicasInmueble);
                }
                else
                {
                    return NotFound("No se encontraron características del inmueble.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

        [HttpPost("insertarCaracteristicaInmueble")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertarCaracteristicaInmueble([FromBody] CaracteristicasInmueble caracteristicaInmueble)
        {
            try
            {
                if (caracteristicaInmueble == null)
                {
                    return BadRequest("La característica del inmueble proporcionada es nula.");
                }

                var resultado = await _caracteristicasInmuebleRepositorio.InsertarCaracteristicaInmueble(caracteristicaInmueble);

                if (resultado > 0)
                {
                    return CreatedAtAction("InsertarCaracteristicaInmueble", new { id = caracteristicaInmueble.IdCaracteristica }, caracteristicaInmueble);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error al insertar la característica del inmueble.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }
    }
}
