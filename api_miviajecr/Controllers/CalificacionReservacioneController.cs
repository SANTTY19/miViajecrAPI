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
    public class CalificacionReservacioneController : ControllerBase
    {
        private readonly ICalificacionReservacioneRepositorio _calificacionReservacioneRepositorio;

        public CalificacionReservacioneController(ICalificacionReservacioneRepositorio calificacionReservacioneRepositorio)
        {
            _calificacionReservacioneRepositorio = calificacionReservacioneRepositorio;
        }

        [HttpGet("obtenerCalificacionesReservaciones")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerCalificacionesReservaciones()
        {
            try
            {
                var calificacionesReservaciones = await _calificacionReservacioneRepositorio.ObtenerCalificacionesReservaciones();

                if (calificacionesReservaciones != null && calificacionesReservaciones.Count > 0)
                {
                    return Ok(calificacionesReservaciones);
                }
                else
                {
                    return NotFound("No se encontraron calificaciones de reservaciones.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

        [HttpPost("insertarCalificacionReservacion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertarCalificacionReservacion([FromBody] CalificacionReservacione calificacionReservacion)
        {
            if (calificacionReservacion == null)
            {
                return BadRequest();
            }

            try
            {
                // Assuming you have validation logic for the model, you can add it here before inserting.
                if (ModelState.IsValid)
                {
                    var result = await _calificacionReservacioneRepositorio.InsertarCalificacionReservacion(calificacionReservacion);

                    if (result > 0)
                    {
                        return Ok("Calificación de reservación insertada correctamente.");
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, "Error al insertar la calificación de reservación.");
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }
    }
}
