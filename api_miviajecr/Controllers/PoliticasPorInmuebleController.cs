using api_miviajecr.Models;
using api_miviajecr.Services.ServicioPoliticas;
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
    public class PoliticasPorInmuebleController : ControllerBase
    {
        private readonly IPoliticasPorInmuebleRepositorio _politicasPorInmuebleRepositorio;

        public PoliticasPorInmuebleController(IPoliticasPorInmuebleRepositorio politicasPorInmuebleRepositorio)
        {
            _politicasPorInmuebleRepositorio = politicasPorInmuebleRepositorio;
        }

        [HttpGet("obtenerPoliticasPorInmueble")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerPoliticasPorInmueble(int idInmueble)
        {
            try
            {
                var politicasPorInmueble = await _politicasPorInmuebleRepositorio.ObtenerPoliticasPorInmueble();

                if (politicasPorInmueble != null && politicasPorInmueble.Any())
                {
                    return Ok(politicasPorInmueble);
                }
                else
                {
                    return NotFound("No se encontraron políticas para el inmueble.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

        [HttpPost("insertarPoliticaPorInmueble")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertarPoliticaPorInmueble([FromBody] PoliticasPorInmueble politicaPorInmueble)
        {
            if (politicaPorInmueble == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await _politicasPorInmuebleRepositorio.InsertarPoliticaPorInmueble(politicaPorInmueble);

                if (result > 0)
                {
                    return Ok("Política por inmueble insertada correctamente.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error al insertar la política por inmueble.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }
    }
}
