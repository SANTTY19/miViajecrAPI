using api_miviajecr.Models;
using api_miviajecr.Services.ServiciosReservaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace api_miviajecr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservacioneController : ControllerBase
    {
        private readonly IReservacioneRepositorio _reservacioneRepositorio;

        public ReservacioneController(IReservacioneRepositorio reservacioneRepositorio)
        {
            _reservacioneRepositorio = reservacioneRepositorio;
        }

        [HttpGet("obtenerReservaciones")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerReservaciones()
        {
            try
            {
                var reservaciones = await _reservacioneRepositorio.ObtenerReservaciones();

                if (reservaciones != null && reservaciones.Count > 0)
                {
                    return Ok(reservaciones);
                }
                else
                {
                    return NotFound("No se encontraron reservaciones.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

        [HttpPost("insertarReservacion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertarReservacion([FromBody] Reservacione reservacion)
        {
            if (reservacion == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await _reservacioneRepositorio.InsertarReservacion(reservacion);

                if (result > 0)
                {
                    return Ok("Reservación insertada correctamente.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error al insertar la reservación.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }
    }
}
