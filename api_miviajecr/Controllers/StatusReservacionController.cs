using api_miviajecr.Models;
using api_miviajecr.Services.ServiciosReservaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusReservacionController : ControllerBase
    {
        private readonly IStatusReservacionRepositorio _statusReservacionRepositorio;

        public StatusReservacionController(IStatusReservacionRepositorio statusReservacionRepositorio)
        {
            _statusReservacionRepositorio = statusReservacionRepositorio;
        }

        [HttpGet("obtenerStatusReservaciones")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerStatusReservaciones()
        {
            try
            {
                var statusReservaciones = await _statusReservacionRepositorio.ObtenerStatusReservaciones();

                if (statusReservaciones != null && statusReservaciones.Count > 0)
                {
                    return Ok(statusReservaciones);
                }
                else
                {
                    return NotFound("No se encontraron status de reservaciones.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }
    }
}
