using api_miviajecr.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioInmueble
{
    public interface IImagenesInmuebleRepositorio
    {
        Task<List<ImagenesInmueble>> ObtenerImagenesInmueble();
        Task<int> InsertarImagenInmueble(ImagenesInmueble imagenInmueble);
    }
}