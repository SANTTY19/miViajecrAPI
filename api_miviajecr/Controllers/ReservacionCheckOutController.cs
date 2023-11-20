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
    public class ReservacionCheckOutController : ControllerBase
    {
        private readonly IReservacionCheckOutRepositorio _reservacionCheckOutRepositorio;

        public ReservacionCheckOutController(IReservacionCheckOutRepositorio reservacionCheckOutRepositorio)
        {
            _reservacionCheckOutRepositorio = reservacionCheckOutRepositorio;
        }

        [HttpPost("realizarCheckOut")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RealizarCheckOut([FromBody] ReservacionCheckOut reservacionCheckOut)
        {
            if (reservacionCheckOut == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await _reservacionCheckOutRepositorio.RealizarCheckOut(reservacionCheckOut);

                if (result > 0)
                {
                    return Ok("Check-out realizado correctamente.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error al realizar el check-out.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }
    }
}
