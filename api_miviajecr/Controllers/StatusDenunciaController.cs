using api_miviajecr.Models;
using api_miviajecr.Services.ServicioDenuncias;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusDenunciaController : ControllerBase
    {
        private readonly IStatusDenunciaRepositorio _statusDenunciaRepositorio;

        public StatusDenunciaController(IStatusDenunciaRepositorio statusDenunciaRepositorio)
        {
            _statusDenunciaRepositorio = statusDenunciaRepositorio;
        }

        [HttpGet("obtenerEstadosDenuncia")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerEstadosDenuncia()
        {
            try
            {
                var estadosDenuncia = await _statusDenunciaRepositorio.ObtenerEstadosDenuncia();

                if (estadosDenuncia != null && estadosDenuncia.Count > 0)
                {
                    return Ok(estadosDenuncia);
                }
                else
                {
                    return NotFound("No se encontraron estados de denuncia.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }
    }
}
