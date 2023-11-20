using api_miviajecr.Models;
using api_miviajecr.Services.ServicioDenuncias;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace api_miviajecr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DenunciaController : ControllerBase
    {
        private readonly IDenunciaRepositorio _denunciaRepositorio;

        public DenunciaController(IDenunciaRepositorio denunciaRepositorio)
        {
            _denunciaRepositorio = denunciaRepositorio;
        }

        // GET: api/Denuncia
        [HttpGet]
        public async Task<IActionResult> ObtenerDenuncias()
        {
            try
            {
                var denuncias = await _denunciaRepositorio.ObtenerDenuncias();
                return Ok(denuncias);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // POST: api/Denuncia
        [HttpPost]
        public async Task<IActionResult> AgregarDenuncia(Denuncia denuncia)
        {
            try
            {
                if (denuncia != null)
                {
                    denuncia.FechaCreacion = DateTime.Now;
                    await _denunciaRepositorio.InsertarDenuncia(denuncia);
                    return Ok("Denuncia agregada exitosamente.");
                }
                else
                {
                    return BadRequest("La denuncia no puede ser nula.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
