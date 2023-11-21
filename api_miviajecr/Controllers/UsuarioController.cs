﻿using api_miviajecr.Services.ServicioUsuario;
using MiBancoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace api_miviajecr.Controllers
{
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        EmailHelper _emailHelper;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _emailHelper = new EmailHelper();
        }

        [HttpPost("api/registrarUsuario")]
        public async Task<IActionResult> RegistrarUsuario(int idTipoUsuario, string nombre, string apellidos, DateTime fechaNacimiento, string numeroTelefono, string fotoIdentificacion, string correoElectronico, string contraseña)
        {
            if (idTipoUsuario == null|| String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(apellidos) || fechaNacimiento == null || String.IsNullOrEmpty(correoElectronico) || String.IsNullOrEmpty(contraseña) || String.IsNullOrEmpty(numeroTelefono))
            {
                return BadRequest();
            }

            return Ok(await _usuarioRepositorio.InsertaUsuario(idTipoUsuario, nombre, apellidos, fechaNacimiento, numeroTelefono, fotoIdentificacion, correoElectronico, contraseña));
        }

        [HttpPost("api/login")]
        public async Task<IActionResult> Login(string correoElectronico, string contraseña)
        {
            if (String.IsNullOrEmpty(correoElectronico) || String.IsNullOrEmpty(contraseña))
            {
                return BadRequest();
            }

            string result = await _usuarioRepositorio.LoginUsuario(correoElectronico, contraseña);
            if (result.Contains("IdUsuario"))
            {
                string[] splitResponse = result.Split(':');
                string jsonResponse = await _usuarioRepositorio.ObtieneTokenPorIdUsuario(Convert.ToInt32(splitResponse[1]));
                dynamic data = JObject.Parse(jsonResponse);
                string dbToken = data.token;

                _emailHelper.EnviarCorreoElectronico(correoElectronico, "miViajeCR | Codigo de verificación", "Tu código es: \n " + dbToken);
            }

            return Ok(result);
        }

        [HttpPost("api/logout")]
        public async Task<IActionResult> Logout(int idUsuario)
        {
            if (idUsuario == null)
            {
                return BadRequest();
            }

            return Ok(await _usuarioRepositorio.LogoutUsuario(idUsuario));
        }

        [HttpPost("api/validarToken")]
        public async Task<IActionResult> ValidarToken(int idUsuario, string token)
        {
            if (String.IsNullOrEmpty(token) || idUsuario == null)
            {
                return BadRequest();
            }

            string result = await _usuarioRepositorio.ObtieneTokenPorIdUsuario(idUsuario);
            dynamic data = JObject.Parse(result);
            string dbToken = data.token;
            if (dbToken.ToLower() == token.ToLower())
            {
                return Ok("Token confirmado.");
            }
            else
            {
                return Ok("Los token no coinciden.");
            }
        }

    }
}
