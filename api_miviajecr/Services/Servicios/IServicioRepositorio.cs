using api_miviajecr.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.Servicios
{
    public interface IServicioRepositorio
    {
        Task<List<Servicio>> ObtenerServicios();
        Task<int> InsertarServicio(Servicio servicio);
    }
}