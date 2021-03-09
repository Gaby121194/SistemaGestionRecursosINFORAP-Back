using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using INFORAP.API.Common.Security;

namespace INFORAP.API.Common.Utility
{
    public interface IMailClient
    {
        void Send(string to, string name, string subject, string body);
    }
    public class MailClient : IMailClient
    {
        private readonly ISecurityConfiguration appSettings;

        public MailClient(ISecurityConfiguration appSettings)
        {
            this.appSettings = appSettings;
        }

        public void Send(string to, string name, string subject, string body)
        {
            var fromAddress = new MailAddress(appSettings.EmailFrom, "Equipo de Inforap");
            var toAddress = new MailAddress(to, name);
            string fromPassword = appSettings.PswFrom;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            } 
        }

    }
}
