﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailService
{
    public interface ISendMail
    {
        Task SendMailAsync(string subject, string content, string toMail);
    }
}
