using api_miviajecr.Models;
using api_miviajecr.Services.ServicioUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MiBancoAPI.Services
{
    public class EmailHelper
    {
        public readonly tiusr27pl_ApimisviajescrContext _dbContext;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        string smtpHost, correoOrigen, contraseñaOrigen = string.Empty;
        int smtpPort = 0;

        public EmailHelper(tiusr27pl_ApimisviajescrContext context, IUsuarioRepositorio usuarioRepositorio)
        {
            this._usuarioRepositorio = usuarioRepositorio;
            this._dbContext = context;
            this.smtpHost = "smtp.gmail.com";
            this.smtpPort = 587;            
        }

        public async Task<string> EnviarCorreoElectronico(int idTipoNotificacion, string correoDestino, string info)
        {
            //obtiene la cuenta de correo a usar
            List<CorreoElectronicoConfig> op;

            try
            {
               op = this._dbContext.CorreoElectronicoConfig.Where(o => o.UsarEstaCuenta).ToList<CorreoElectronicoConfig>();
               if (op.Count > 0)
               {
                    this.correoOrigen = op[0].CorreoElectronicoSmtp;
                    this.contraseñaOrigen = op[0].ContraseñaSmtp;
               }
                else
                {
                    return "no se ha configurado ninguna cuenta de correo electronico para la salida de las notificaciones..";
                }
            }
            catch (Exception ex)
            {
                return "no se pudo obtener la cuenta principal para el envio de correos. errorMEssage: " + ex.Message;
            }

            //obtiene la plantilla a usar
            List<PlantillasNotificacionPorCorreo> plantillas;
            try
            {
                 plantillas = await this._usuarioRepositorio.ObtienePlantillaPorTipoNotificacion(idTipoNotificacion);
            }
            catch (Exception ex )
            {

                return "no se pudo obtener la plantilla. errorMEssage: " + ex.Message;
            }

            //arma el correo por enviar
            string resultado = String.Empty;
            if (!String.IsNullOrEmpty(correoDestino))
            {
                try
                {
                    string strBody = plantillas[0].PlantillaHtml.
                        Replace("[pieDePagina]", plantillas[0].PieDePaginaPlantilla);

                    string strBody2 = strBody.Replace("[tituloPlantilla]", plantillas[0].TituloPlantilla);

                    string strBody3 = strBody2.Replace("{cuerpo}", plantillas[0].CuerpoPlantilla.Replace("{info}", info));

                    var mensaje = new MailMessage();
                    mensaje.From = new MailAddress(this.correoOrigen);
                    mensaje.To.Add(correoDestino);
                    mensaje.Subject = plantillas[0].SujetoPlantilla;

                    AlternateView imgView = AlternateView.CreateAlternateViewFromString(strBody3.Replace("[imgLogo]", "<img id='miViajeCrLogo' src=cid:imgPath >"), null, "text/html");
                    LinkedResource lr = new LinkedResource("Images/miViajeCrLogo.png");
                    lr.ContentId = "imgPath";
                    imgView.LinkedResources.Add(lr);
                    mensaje.AlternateViews.Add(imgView);
                    mensaje.Body = lr.ContentId;                    

                    var clienteSMTP = new SmtpClient(this.smtpHost, this.smtpPort);
                    clienteSMTP.EnableSsl = true;
                    clienteSMTP.Credentials = new NetworkCredential(this.correoOrigen, this.contraseñaOrigen);           

                    clienteSMTP.Send(mensaje);
                    resultado = "Email enviado con exito.";
                }
                catch (Exception e)
                {
                    resultado = "Hubo un problema al enviar el correo. Error: " + e.Message;
                    throw;
                }
            }
            else
            {
                resultado = "El correo destino es requerido";
            }

            return resultado;
        }        
    }
}
