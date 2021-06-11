using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Theworkspacerd.Web.Models;

namespace Theworkspacerd.Web.Helpers
{
    public class SendEmail : ISendEmail
    {
        private readonly MailSettings _mailSettings;

        public SendEmail(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }


        public bool enviarEmailCliente(string Address,string subje, TransacionPaypal data)
        {

            var fromAddress = new MailAddress(_mailSettings.Mail);
            var toAddress = new MailAddress(Address);
             string fromPassword = _mailSettings.Password;
             string subject = subje;

            var webclient = new WebClient();
            string mailBody = webclient.DownloadString(_mailSettings.RutaEmail);

            //string strFileMail = _mailSettings.RutaEmail;
            //StreamReader stream = new StreamReader(strFileMail);
            //string mailBody = stream.ReadToEnd();
            //stream.Close();

            mailBody = mailBody.Replace("$Id$", data.Id);
            mailBody = mailBody.Replace("$FechaReserva$", DateTime.Now.ToString("dd/mm/yyyy"));
            mailBody = mailBody.Replace("$Titular$", data.Email_address);
            mailBody = mailBody.Replace("$Description$", data.Description);
            mailBody = mailBody.Replace("$Amount$", data.Amount);
            mailBody = mailBody.Replace("$Currency_code$", data.Currency_code);
            mailBody = mailBody.Replace("$Estado$", data.Status);

            var smtp = new SmtpClient
            {
                Host = _mailSettings.Host,
                Port = _mailSettings.Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            

            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            mail.Subject = subject;
            mail.Body = mailBody;
            mail.From = new MailAddress(fromAddress.Address);
            mail.To.Add(toAddress);
            smtp.Send(mail);
            return true;
        }

        public bool enviarEmailEmpresa(string subje, TransacionPaypal data)
        {

            var fromAddress = new MailAddress(_mailSettings.Mail);
            var toAddress = new MailAddress(_mailSettings.Mail);
            string fromPassword = _mailSettings.Password;
            string subject = subje;

            //string strFileMail = _mailSettings.RutaEmail;
            //StreamReader stream = new StreamReader(strFileMail);
            //string mailBody = stream.ReadToEnd();
            //stream.Close();

            var webclient = new WebClient();
            string mailBody = webclient.DownloadString(_mailSettings.RutaEmail);

            mailBody = mailBody.Replace("$Id$", data.Id);
            mailBody = mailBody.Replace("$FechaReserva$", DateTime.Now.ToString("dd/mm/yyyy"));
            mailBody = mailBody.Replace("$Titular$", data.Email_address);
            mailBody = mailBody.Replace("$Description$", data.Description);
            mailBody = mailBody.Replace("$Amount$", data.Amount);
            mailBody = mailBody.Replace("$Currency_code$", data.Currency_code);
            mailBody = mailBody.Replace("$Estado$", data.Status);

            var smtp = new SmtpClient
            {
                Host = _mailSettings.Host,
                Port = _mailSettings.Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            mail.Subject = subject;
            mail.Body = mailBody;
            mail.From = new MailAddress(fromAddress.Address);
            mail.To.Add(fromAddress.Address);
            smtp.Send(mail);

            return true;
        }

        public bool enviarEmail(Mensaje mensaje)
        {

            var fromAddress = new MailAddress(_mailSettings.Mail);
            var toAddress = new MailAddress(mensaje.Email);
            string fromPassword = _mailSettings.Password;
            string subject = $"Comentario de:{mensaje.Nombre}<br/> desde {mensaje.Email}";


     

            var smtp = new SmtpClient
            {
                Host = _mailSettings.Host,
                Port = _mailSettings.Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };


            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            mail.Subject = subject;
            mail.Body =mensaje.Texto ;
            mail.From = new MailAddress(fromAddress.Address);
            mail.To.Add(fromAddress.Address);
            smtp.Send(mail);
            return true;
        }

    }
}

