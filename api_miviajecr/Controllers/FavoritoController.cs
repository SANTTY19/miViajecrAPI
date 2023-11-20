using api_miviajecr.Models;
using api_miviajecr.Services.ServicioFavoritos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritoController : ControllerBase
    {
        private readonly IFavoritoRepositorio _favoritoRepositorio;

        public FavoritoController(IFavoritoRepositorio favoritoRepositorio)
        {
            _favoritoRepositorio = favoritoRepositorio;
        }

        [HttpGet("obtenerFavoritos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerFavoritos()
        {
            try
            {
                var favoritos = await _favoritoRepositorio.ObtenerFavoritos();

                if (favoritos != null && favoritos.Count > 0)
                {
                    return Ok(favoritos);
                }
                else
                {
                    return NotFound("No se encontraron favoritos.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }
    }
}
