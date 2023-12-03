using System;
using System.Threading.Tasks;

namespace api_miviajecr.Services.ServicioUsuario
{
    public interface IUsuarioRepositorio
    {
        Task<string> InsertaUsuario(int idTipoUsuario, string nombre, string apellidos, DateTime fechaNacimiento, string numeroTelefono, string fotoIdentificacion, string correoElectronico, string contraseña);

        Task<string> LoginUsuario(string correoElectronico, string contraseña);

        Task<string> LogoutUsuario(int idUsuario);

        Task<string> ObtieneTokenPorIdUsuario(int idUsuario);
    }
}
