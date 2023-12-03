using api_miviajecr.Models;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api_miviajecr.Services
{
    public class Cotizacion : ICotizacion
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public Cotizacion(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CotizacionModel> CalcularCotizacion(int inmuebleId, int cantidadHuespedes, int cantidadDias)
        {
            var cotizacionModel = new CotizacionModel();

            try
            {
                var precioPorNoche = await _dbContext.Inmuebles
                    .Where(i => i.IdInmueble == inmuebleId)
                    .Select(i => i.PrecioPorNoche)
                    .FirstOrDefaultAsync();

                if (precioPorNoche > 0)
                {
                    var impuestoHuespedes = precioPorNoche * 0.05m * (cantidadHuespedes - 1);
                    var precioTotalPorNocheConImpuestos = precioPorNoche + impuestoHuespedes;
                    var precioTotalConImpuestosPorDias = precioTotalPorNocheConImpuestos * cantidadDias;

                    cotizacionModel.InmuebleId = inmuebleId;
                    cotizacionModel.CantidadHuespedes = cantidadHuespedes;
                    cotizacionModel.CantidadDias = cantidadDias;
                    cotizacionModel.PrecioTotalPorNocheConImpuestos = precioTotalPorNocheConImpuestos;
                    cotizacionModel.PrecioTotalConImpuestosPorDias = precioTotalConImpuestosPorDias;
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores aquí
                Console.WriteLine($"Error al calcular la cotización: {ex.Message}");
            }

            return cotizacionModel;
        }
    }
}

