using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MailNegocio
    {
        private string host = ConfigurationManager.AppSettings["mailHost"];
        private int port = int.Parse(ConfigurationManager.AppSettings["mailPort"]);
        private string user = ConfigurationManager.AppSettings["mailUser"];
        private string pass = ConfigurationManager.AppSettings["mailPass"];
        private string from = ConfigurationManager.AppSettings["mailFrom"];

        public void EnviarMailOTCreada(string emailCliente, string nombreCliente, int idOrden, string descripcion)
        {
            try
            {
                var mensaje = new MailMessage();
                mensaje.From = new MailAddress(from, "Taller Mecánico");
                mensaje.To.Add(emailCliente);
                mensaje.Subject = $"OT #{idOrden} — Tu vehículo ingresó al taller";
                mensaje.IsBodyHtml = true;
                mensaje.Body = $@"
                    <!DOCTYPE html>
                    <html>
                    <body style='font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px;'>
                        <div style='max-width: 600px; margin: auto; background-color: #ffffff; border-radius: 8px; overflow: hidden; box-shadow: 0 2px 8px rgba(0,0,0,0.1);'>
                            <div style='background-color: #1a1a1a; padding: 24px; text-align: center;'>
                                <h1 style='color: #ffffff; margin: 0;'>🔧 Taller Mecánico</h1>
                            </div>
                            <div style='padding: 32px;'>
                                <h2 style='color: #333;'>¡Hola {nombreCliente}!</h2>
                                <p style='color: #555; font-size: 16px;'>Tu vehículo ingresó al taller correctamente.</p>
            
                                <div style='background-color: #f9f9f9; border-left: 4px solid #1a1a1a; padding: 16px; margin: 24px 0; border-radius: 4px;'>
                                    <p style='margin: 4px 0; color: #333;'><strong>Número de OT:</strong> #{idOrden}</p>
                                    <p style='margin: 4px 0; color: #333;'><strong>Descripción:</strong> {descripcion}</p>
                                </div>

                                <p style='color: #555;'>Te avisaremos cuando esté listo para retirar.</p>
                            </div>
                            <div style='background-color: #f0f0f0; padding: 16px; text-align: center;'>
                                <p style='color: #999; font-size: 12px; margin: 0;'>Taller Mecánico — Este es un mail automático, no respondas este correo.</p>
                            </div>
                        </div>
                    </body>
                    </html>";

                var smtp = new SmtpClient(host, port);
                smtp.Credentials = new NetworkCredential(user, pass);
                smtp.EnableSsl = false;
                smtp.Send(mensaje);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EnviarMailOTCerrada(string emailCliente, string nombreCliente, int idOrden, decimal total)
        {
            try
            {
                var mensaje = new MailMessage();
                mensaje.From = new MailAddress(from, "Taller Mecánico");
                mensaje.To.Add(emailCliente);
                mensaje.Subject = $"OT #{idOrden} — Tu vehiculo esta ready";
                mensaje.IsBodyHtml = true;
                mensaje.Body = $@"
                    <!DOCTYPE html>
                    <html>
                    <body style='font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px;'>
                        <div style='max-width: 600px; margin: auto; background-color: #ffffff; border-radius: 8px; overflow: hidden; box-shadow: 0 2px 8px rgba(0,0,0,0.1);'>
                            <div style='background-color: #1a1a1a; padding: 24px; text-align: center;'>
                                <h1 style='color: #ffffff; margin: 0;'>🔧 Taller Mecánico</h1>
                            </div>
                            <div style='padding: 32px;'>
                                <h2 style='color: #333;'>¡Hola {nombreCliente}!</h2>
                                <p style='color: #555; font-size: 16px;'>Tu vehículo está listo para retirar y salir arando.</p>
            
                                <div style='background-color: #f9f9f9; border-left: 4px solid #1a1a1a; padding: 16px; margin: 24px 0; border-radius: 4px;'>
                                    <p style='margin: 4px 0; color: #333;'><strong>Número de OT:</strong> #{idOrden}</p>
                                    <p style='margin: 4px 0; color: #333;'><strong>Total a abonar:</strong> {total:C}</p>
                                </div>

                                <p style='color: #555;'>Podés pasar a retirarlo por el taller.</p>
                                <p style='color: #e74c3c; font-size: 13px;'>⚠️ Si venís después de las 18hs nos fuimos.</p>
                            </div>
                            <div style='background-color: #f0f0f0; padding: 16px; text-align: center;'>
                                <p style='color: #999; font-size: 12px; margin: 0;'>Taller Mecánico — Este es un mail automático, no respondas este correo.</p>
                            </div>
                        </div>
                    </body>
                    </html>";

                var smtp = new SmtpClient(host, port);
                smtp.Credentials = new NetworkCredential(user, pass);
                smtp.EnableSsl = false;
                smtp.Send(mensaje);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
