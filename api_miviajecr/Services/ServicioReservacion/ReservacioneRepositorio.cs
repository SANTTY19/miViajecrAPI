﻿using api_miviajecr.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServiciosReservaciones
{
    public class ReservacioneRepositorio : IReservacioneRepositorio
    {
        private readonly tiusr27pl_ApimisviajescrContext _dbContext;

        public ReservacioneRepositorio(tiusr27pl_ApimisviajescrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Reservacione>> ObtenerReservaciones()
        {
            return await _dbContext.Reservaciones.ToListAsync();
        }

        public async Task<int> InsertarReservacion(Reservacione reservacion)
        {
            if (reservacion != null)
            {
                _dbContext.Reservaciones.Add(reservacion);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }

        public async Task<List<CalificacionesCustom>> ObtenerInfoReservacion(int idInmueble)
        {
            return await _dbContext.CalificacionesCustom
               .FromSqlRaw<CalificacionesCustom>("ObtenerInfoReservacion {0}", idInmueble)
               .ToListAsync();
        }

        public async Task<List<ReservacionCustom>> ObtenerReservacionesPorIdUsuario(int idUsuario)
        {
            return await _dbContext.ReservacionCustom.
                  FromSqlRaw<ReservacionCustom>("ObtenerReservacionesPorUsuario {0}", idUsuario)
                  .ToListAsync();
        }
    }
}
