using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace MailWorker
{
    public class SendMail :ISendMail
    {
        public SendMail() { }
        public async Task SendMailAsync(string subject, string content, string toMail)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDAPIKEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(Environment.GetEnvironmentVariable("MAIL"), "Østrup Medborgerhus");
            var to = new EmailAddress(toMail, "Do not reply");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            await client.SendEmailAsync(msg);
        }
    }
}
