using api_miviajecr.Models;
using api_miviajecr.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace api_miviajecr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotizacionController : ControllerBase
    {
        private readonly ICotizacion _cotizacionService;

        public CotizacionController(ICotizacion cotizacionService)
        {
            _cotizacionService = cotizacionService ?? throw new ArgumentNullException(nameof(cotizacionService));
        }

        [HttpGet("calcular")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CotizacionModel>> CalcularCotizacion(
            [FromQuery] int inmuebleId,
            [FromQuery] int cantidadHuespedes,
            [FromQuery] int cantidadDias)
        {
            try
            {
                var cotizacionResult = await _cotizacionService.CalcularCotizacion(inmuebleId, cantidadHuespedes, cantidadDias);

                if (cotizacionResult != null)
                {
                    return Ok(cotizacionResult);
                }
                else
                {
                    return BadRequest("No se pudo calcular la cotización.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al calcular la cotización: {ex.Message}");
            }
        }
    }
}

