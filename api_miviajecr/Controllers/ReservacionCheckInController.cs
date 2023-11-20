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
    public class ReservacionCheckInController : ControllerBase
    {
        private readonly IReservacionCheckInRepositorio _reservacionCheckInRepositorio;

        public ReservacionCheckInController(IReservacionCheckInRepositorio reservacionCheckInRepositorio)
        {
            _reservacionCheckInRepositorio = reservacionCheckInRepositorio;
        }

        [HttpPost("realizarCheckIn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RealizarCheckIn([FromBody] ReservacionCheckIn reservacionCheckIn)
        {
            if (reservacionCheckIn == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await _reservacionCheckInRepositorio.RealizarCheckIn(reservacionCheckIn);

                if (result > 0)
                {
                    return Ok("Check-in realizado correctamente.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error al realizar el check-in.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }
    }
}
