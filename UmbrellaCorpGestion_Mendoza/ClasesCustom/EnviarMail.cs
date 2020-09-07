using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace UmbrellaCorpGestion_Mendoza.ClasesCustom
{
    public class EnviarMail
    {
        public static void EnviarContraseniaAlCorreo(string mail, string nvaContrasenia, Label lbl) {

            // Creo un nuevo objeto de tipo Message
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //direccion de correr "para"
            mmsg.To.Add(mail);
            //mmsg.Bcc.Add("Mails en CCO"); // esto es para enviar CCO

            //Asunto - Subject

            mmsg.Subject = "Restablecimiento de contraseña";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Cuerpo o Body
            mmsg.Body = "Su nueva contraseña al sitio de UmbrellaCorp es >> "+nvaContrasenia;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = false;

            //Correo desde el cual voy a enviar el mail

            mmsg.From = new System.Net.Mail.MailAddress("admin@gmail.com");// se debe conolar el mail propio

            // Datos del cliente de mail

            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            cliente.Credentials = new System.Net.NetworkCredential("admin@gmail.com", "admin");//se debe colocar el mail y contraseña propio para que funcione

            cliente.Port = 587;

            cliente.EnableSsl = true;

            cliente.Host = "smtp.gmail.com";
            // datos del cliente definidos

            try
            {
                cliente.Send(mmsg);
            }

            catch (System.Net.Mail.SmtpException ex)
            {
                lbl.Text = "Su contraseña ha sido modificada exitosamente";//se debe cambiar la excepcion

            }

        }
    }
}