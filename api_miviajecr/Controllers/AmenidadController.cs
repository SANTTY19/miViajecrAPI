using api_miviajecr.Models;
using api_miviajecr.Services.ServicioAmenidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AmenidadController : ControllerBase
    {
        private readonly IAmenidadRepositorio _amenidadRepositorio;

        public AmenidadController(IAmenidadRepositorio amenidadRepositorio)
        {
            _amenidadRepositorio = amenidadRepositorio;
        }

        [HttpGet("obtenerAmenidades")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerAmenidades()
        {
            try
            {
                var amenidades = await _amenidadRepositorio.ObtenerAmenidades();

                if (amenidades != null && amenidades.Count > 0)
                {
                    return Ok(amenidades);
                }
                else
                {
                    return NotFound("No se encontraron amenidades.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

        [HttpPost("insertarAmenidad")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertarAmenidad([FromBody] Amenidade amenidad)
        {
            if (amenidad == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await _amenidadRepositorio.InsertarAmenidad(amenidad);

                if (result > 0)
                {
                    return Created($"/api/amenidad/{amenidad.IdAmenidad}", amenidad);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error al insertar la amenidad.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }
        [HttpPut("modificarAmenidad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ModificarAmenidad([FromBody] Amenidade amenidad)
        {
            if (amenidad == null)
            {
                return BadRequest();
            }

            try
            {
                var resultado = await _amenidadRepositorio.ModificarAmenidad(amenidad);

                if (resultado > 0)
                {
                    return Ok("Amenidad modificada exitosamente.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error al modificar la amenidad.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

    }
}