using api_miviajecr.Models;
using api_miviajecr.Services.ServicioInmueble;
using api_miviajecr.Services.ServicioPoliticas;
using api_miviajecr.Services.ServicioRestricciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace api_miviajecr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InmuebleController : ControllerBase
    {
        private readonly IInmuebleRepositorio _inmuebleRepositorio;
        private readonly IImagenesInmuebleRepositorio _imagenRepositorio;
        private readonly IUbicacionInmuebleRepositorio _ubicacionRepositorio;
        private readonly IServiciosPorInmuebleRepositorio _servicioRepositorio;
        private readonly IAmenidadesPorInmuebleRepositorio _amenidadRepositorio;
        private readonly IRestriccionesPorInmuebleRepositorio _restriccionRepositorio;
        private readonly IPoliticasPorInmuebleRepositorio _politicaRepositorio;
        private readonly ICaracteristicasInmuebleRepositorio _caracteristicaRepositorio;

        public InmuebleController(IInmuebleRepositorio inmuebleRepositorio, 
            IImagenesInmuebleRepositorio imagenRepositorio,
            IUbicacionInmuebleRepositorio ubicacionRepositorio,
            IServiciosPorInmuebleRepositorio servicioRepositorio,
            IAmenidadesPorInmuebleRepositorio amenidadRepositorio,
            IRestriccionesPorInmuebleRepositorio restriccionRepositorio,
            IPoliticasPorInmuebleRepositorio politicaRepositorio,
            ICaracteristicasInmuebleRepositorio caracteristicaRepositorio)
        {
            _inmuebleRepositorio = inmuebleRepositorio;
            _imagenRepositorio = imagenRepositorio;
            _ubicacionRepositorio = ubicacionRepositorio;
            _servicioRepositorio = servicioRepositorio;
            _amenidadRepositorio = amenidadRepositorio;
            _restriccionRepositorio = restriccionRepositorio;
            _politicaRepositorio = politicaRepositorio;
            _caracteristicaRepositorio = caracteristicaRepositorio;
        }

        [HttpGet("obtenerInmueblesCards")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerInmueblesCards()
        {
            try
            {
                var inmueblesCards = await _inmuebleRepositorio.ObtenerInmueblesCards();

                if (inmueblesCards != null && inmueblesCards.Count > 0)
                {
                    return Ok(inmueblesCards);
                }
                else
                {
                    return NotFound("No se encontraron inmuebles.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

        [HttpGet("obtenerInmuebles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerInmuebles()
        {
            try
            {
                var inmuebles = await _inmuebleRepositorio.ObtenerInmuebles();

                if (inmuebles != null && inmuebles.Count > 0)
                {
                    return Ok(inmuebles);
                }
                else
                {
                    return NotFound("No se encontraron inmuebles.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

        [HttpPost("insertarInmueble")]
        public async Task<IActionResult> InsertarInmueble([FromBody] InmuebleCustom inmueble)
        {
            try
            {
                if (inmueble == null)
                {
                    return BadRequest("El inmueble proporcionado es nulo.");
                }

                string inmuebleResult = await _inmuebleRepositorio.InsertarInmueble(inmueble);
                if (inmuebleResult.Contains("IdInmueble"))
                {
                    string[] splitResponse = inmuebleResult.Split(':');
                    int idInmueble = Convert.ToInt32(splitResponse[1].ToString());

                    int caracteristicaResult = 0;
                    foreach (CaracteristicasInmuebleCustom item in inmueble.Caracteristicas)
                    {
                        CaracteristicasInmuebleCustom ci = new CaracteristicasInmuebleCustom();
                        ci.cantidadHuespedes= item.cantidadHuespedes;
                        ci.cantidadHabitaciones= item.cantidadHabitaciones;
                        ci.cantidadCamas = item.cantidadCamas;
                        ci.cantidadBaños = item.cantidadBaños;

                        CaracteristicasInmueble cc = new CaracteristicasInmueble();
                        cc.IdInmueble = idInmueble;
                        cc.Descripcion = JsonConvert.SerializeObject(ci);


                        caracteristicaResult = await _caracteristicaRepositorio.InsertarCaracteristicaInmueble(cc);
                        if (caracteristicaResult <= 0)
                        {
                            return Ok("error al guardar la caracteristica del inmueble");
                        }
                    }

                    int imagenResult = 0;
                    foreach (ImagenesInmueble item in inmueble.Imagenes)
                    {
                        ImagenesInmueble ii = new ImagenesInmueble();
                        ii.IdInmueble = idInmueble;
                        ii.Descripcion = item.Descripcion;
                        ii.EstaActivo = true;
                        ii.FechaCreacion = DateTime.Now;
                        imagenResult = await _imagenRepositorio.InsertarImagenInmueble(ii);
                        if (imagenResult <= 0)
                        {
                            return Ok("error al guardar la imagen del inmueble");
                        }                        
                    }

                    int servicioResult = 0;
                    foreach (ServiciosPorInmueble item in inmueble.Servicios)
                    {
                        ServiciosPorInmueble si = new ServiciosPorInmueble();
                        si.IdInmueble = idInmueble;
                        si.IdServicio = item.IdServicio;
                        si.EstaActivo = true;
                        si.FechaCreacion = DateTime.Now;
                        servicioResult = await _servicioRepositorio.InsertarServicioPorInmueble(si);
                        if (servicioResult <= 0)
                        {
                            return Ok("error al guardar el servicio del inmueble");
                        }
                    }

                    int amenidadResult = 0;
                    foreach (AmenidadesPorInmueble item in inmueble.Amenidades)
                    {
                        AmenidadesPorInmueble ai = new AmenidadesPorInmueble();
                        ai.IdInmueble = idInmueble;
                        ai.IdAmenidad = item.IdAmenidad;
                        ai.EstaActivo = true;
                        ai.FechaCreacion = DateTime.Now;
                        amenidadResult = await _amenidadRepositorio.InsertarAmenidadPorInmueble(ai);
                        if (amenidadResult <= 0)
                        {
                            return Ok("error al guardar la amenidad del inmueble");
                        }
                    }

                    int restriccionResult = 0;
                    foreach (RestriccionesPorInmueble item in inmueble.Restricciones)
                    {
                        RestriccionesPorInmueble ri = new RestriccionesPorInmueble();
                        ri.IdInmueble = idInmueble;
                        ri.IdRestriccion = item.IdRestriccion;
                        ri.EstaActivo = true;
                        ri.FechaCreacion = DateTime.Now;
                        restriccionResult = await _restriccionRepositorio.InsertarRestriccionPorInmueble(ri);
                        if (restriccionResult <= 0)
                        {
                            return Ok("error al guardar la restriccion del inmueble");
                        }
                    }

                    int politicaResult = 0;
                    foreach (PoliticasPorInmueble item in inmueble.Politicas)
                    {
                        PoliticasPorInmueble pi = new PoliticasPorInmueble();
                        pi.IdInmueble = idInmueble;
                        pi.IdPolitica= item.IdPolitica;
                        pi.EstaActivo = true;
                        pi.FechaCreacion = DateTime.Now;
                        politicaResult = await _politicaRepositorio.InsertarPoliticaPorInmueble(pi);
                        if (politicaResult <= 0)
                        {
                            return Ok("error al guardar la politica del inmueble");
                        }
                    }

                    int ubicacionResult = 0;
                    foreach (UbicacionInmueble item in inmueble.Ubicacion)
                    {
                        UbicacionInmueble ui = new UbicacionInmueble();
                        ui.IdInmueble = idInmueble;
                        ui.Provincia = item.Provincia;
                        ui.Canton = item.Canton;
                        ui.Distrito = item.Distrito;
                        ui.UbicacionDetalles = item.UbicacionDetalles;
                        ubicacionResult = await _ubicacionRepositorio.InsertarUbicacionInmueble(ui);
                        if (ubicacionResult <= 0)
                        {
                            return Ok("error al guardar la ubicacion del inmueble");
                        }
                    }

                }

                return Ok(inmuebleResult);                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("obtenerInmueblesFavoritos/{idInmueble}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerInmueblesFavoritos(int idInmueble)
        {
            try
            {
                var inmuebles = await _inmuebleRepositorio.ObtenerInmueblesFavoritos(idInmueble);

                if (inmuebles != null && inmuebles.Count > 0)
                {
                    return Ok(inmuebles);
                }
                else
                {
                    return NotFound("No se encontraron inmuebles.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }

        [HttpPost("agregarInmuebleAFavoritos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AgregarInmuebleAFavoritos(int idUsuario, int idInmueble)
        {
            if (idUsuario <= 0 || idInmueble <= 0)
            {
                return BadRequest();
            }

            return Ok(await _inmuebleRepositorio.AgregarInmuebleAFavoritos(idUsuario, idInmueble));
        }
    }
}
