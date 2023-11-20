using api_miviajecr.Models;
using api_miviajecr.Services.ServicioHistoricoLugaresVisitado;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoricoLugaresVisitadoController : ControllerBase
    {
        private readonly IHistoricoLugaresVisitadoRepositorio _historicoLugaresVisitadoRepositorio;

        public HistoricoLugaresVisitadoController(IHistoricoLugaresVisitadoRepositorio historicoLugaresVisitadoRepositorio)
        {
            _historicoLugaresVisitadoRepositorio = historicoLugaresVisitadoRepositorio;
        }

        [HttpGet("obtenerHistoricoLugaresVisitados")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerHistoricoLugaresVisitados()
        {
            try
            {
                var historicoLugaresVisitados = await _historicoLugaresVisitadoRepositorio.ObtenerHistoricoLugaresVisitados();

                if (historicoLugaresVisitados != null && historicoLugaresVisitados.Count > 0)
                {
                    return Ok(historicoLugaresVisitados);
                }
                else
                {
                    return NotFound("No se encontraron historicos de lugares visitados.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }
    }
}
