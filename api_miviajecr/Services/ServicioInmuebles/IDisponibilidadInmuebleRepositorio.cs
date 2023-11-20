using api_miviajecr.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioInmueble
{
    public interface IDisponibilidadInmuebleRepositorio
    {
        Task<List<DisponibilidadInmueble>> ObtenerDisponibilidadInmueble();
        Task<int> InsertarDisponibilidadInmueble(DisponibilidadInmueble disponibilidadInmueble);
    }
}