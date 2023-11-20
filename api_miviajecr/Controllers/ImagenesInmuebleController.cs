using api_miviajecr.Models;
using api_miviajecr.Services.ServicioInmueble;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagenesInmuebleController : ControllerBase
    {
        private readonly IImagenesInmuebleRepositorio _imagenesInmuebleRepositorio;

        public ImagenesInmuebleController(IImagenesInmuebleRepositorio imagenesInmuebleRepositorio)
        {
            _imagenesInmuebleRepositorio = imagenesInmuebleRepositorio;
        }

        [HttpGet("obtenerImagenesInmueble")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerImagenesInmueble()
        {
            try
            {
                var imagenesInmueble = await _imagenesInmuebleRepositorio.ObtenerImagenesInmueble();

                if (imagenesInmueble != null && imagenesInmueble.Count > 0)
                {
                    return Ok(imagenesInmueble);
                }
                else
                {
                    return NotFound("No se encontró información de imágenes de inmuebles.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

        [HttpPost("insertarImagenInmueble")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertarImagenInmueble([FromBody] ImagenesInmueble imagenInmueble)
        {
            try
            {
                if (imagenInmueble == null)
                {
                    return BadRequest("Los datos de la imagen de inmueble son nulos.");
                }

                var result = await _imagenesInmuebleRepositorio.InsertarImagenInmueble(imagenInmueble);

                if (result > 0)
                {
                    return Ok("Imagen de inmueble insertada correctamente.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error al insertar imagen de inmueble.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }
    }
}