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
    public class PoliticaController : ControllerBase
    {
        private readonly IPoliticaRepositorio _politicaRepositorio;

        public PoliticaController(IPoliticaRepositorio politicaRepositorio)
        {
            _politicaRepositorio = politicaRepositorio;
        }

        [HttpGet("obtenerPoliticas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerPoliticas()
        {
            try
            {
                var politicas = await _politicaRepositorio.ObtenerPoliticas();

                if (politicas != null && politicas.Any())
                {
                    return Ok(politicas);
                }
                else
                {
                    return NotFound("No se encontraron políticas.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

        [HttpPost("insertarPolitica")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertarPolitica([FromBody] Politica politica)
        {
            if (politica == null)
            {
                return BadRequest();
            }

            try
            {
                var resultado = await _politicaRepositorio.InsertarPolitica(politica);

                if (resultado > 0)
                {
                    return Ok("Política insertada exitosamente.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error al insertar la política.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }
    }
}