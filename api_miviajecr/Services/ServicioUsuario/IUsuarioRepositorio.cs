﻿using api_miviajecr.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioUsuario
{
    public interface IUsuarioRepositorio
    {
        Task<string> InsertaUsuario(int idTipoUsuario, string nombre, string apellidos, DateTime fechaNacimiento, string numeroTelefono, string fotoIdentificacion, string correoElectronico, string contraseña);

        Task<string> LoginUsuario(string correoElectronico, string contraseña);

        Task<string> LogoutUsuario(int idUsuario);

        Task<string> ObtieneTokenPorIdUsuario(int idUsuario);

        Task<List<PlantillasNotificacionPorCorreo>> ObtienePlantillaPorTipoNotificacion(int idTipoNotificacion);

        Task<List<CorreoElectronicoConfig>> ObtieneCuentasAdminCorreo();

        Task<List<PlantillasNotificacionPorCorreo>> ObtienePlantillasNotificaciones();

        Task<string> InsertaPlantilla(string plantillaHtml, string sujetoPlantilla, string tituloPlantilla, string cuerpoPlantilla, string pieDePaginaPlantilla);

        Task<List<UsuarioCustom>> ObtieneUsuarioPorId(int idUsuario);

        Task<string> VerificaCorreoElectronico(string correoElectronico);

        Task<List<Notificaciones>> ObtieneNotificacionesPorIdUsuario(int idUsuario);

        Task<string> InsertaNotificacionUsuario (int idUsuario, string notificacion);

        Task<string> ActualizaNotificacion(int idNotificacion, bool fueLeida);

        Task<List<Usuario>> ObtenerUsuarios();
    }
}
