using api_miviajecr.Models;
using api_miviajecr.Services.Servicios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioInmueble
{
    public class ServicioRepositorio : IServicioRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public ServicioRepositorio(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Servicio>> ObtenerServicios()
        {
            return await _dbContext.Servicios.ToListAsync();
        }

        public async Task<int> InsertarServicio(Servicio servicio)
        {
            if (servicio != null)
            {
                _dbContext.Servicios.Add(servicio);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }
        public async Task<int> ModificarServicio(Servicio servicio)
        {
            try
            {
                var servicioExistente = await _dbContext.Servicios.FindAsync(servicio.IdServicio);

                if (servicioExistente != null)
                {
                    servicioExistente.Descripcion = servicio.Descripcion;
                    servicioExistente.EstaActivo = servicio.EstaActivo;
                    servicioExistente.FechaCreacion = servicio.FechaCreacion;
                    servicioExistente.IconUrl = servicio.IconUrl;

                    _dbContext.Servicios.Update(servicioExistente);
                    return await _dbContext.SaveChangesAsync();
                }
                else
                {
                    return -1; // O un código que indique que no se encontró el servicio
                }
            }
            catch (Exception)
            {
                // Manejar excepciones si es necesario
                throw; // O retornar un valor específico en caso de error
            }
        }

    }
}