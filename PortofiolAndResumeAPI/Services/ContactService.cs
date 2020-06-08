using PortofiolAndResumeAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PortofiolAndResumeAPI.Services
{
    public class ContactService
    {
        protected const string myEmail = "ricardo-ss@hotmail.com";
        protected const string password = "Viviana12";
        public async Task<bool> SendEmail(ContactFormInfo info)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(info.email);
                message.To.Add(new MailAddress(myEmail));
                message.Subject = info.request;
                message.Body = info.message;
                smtp.Port = 587;
                smtp.Host = "smtp.live.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(myEmail, password);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                return await Task.Run(() => true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
