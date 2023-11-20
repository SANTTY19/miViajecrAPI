using api_miviajecr.Services.ServicioAmenidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using api_miviajecr.Services.ServicioInmuebles;
using Microsoft.EntityFrameworkCore;

namespace api_miviajecr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleInmuebleController : ControllerBase
    {
        private readonly IDetalle _detalleinmueble;

        public DetalleInmuebleController(IDetalle detalleRepo)
        {
            _detalleinmueble = detalleRepo;
        }

        [HttpGet("obtenerDetallesInmuebles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerDetalles()
        {
            try
            {
                var detalles = await _detalleinmueble.ObtenerInformacionInmuebles();

                if (detalles != null && detalles.Count > 0)
                {
                    return Ok(detalles);
                }
                else
                {
                    return NotFound("No se encontraron detalles.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }
    }
}
