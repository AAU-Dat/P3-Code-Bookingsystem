using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace MailWorker
{
    public interface ISendMail
    {
        Task SendMailAsync(string subject, string content, string toMail);
    }
}
