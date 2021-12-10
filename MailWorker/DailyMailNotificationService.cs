using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MailWorker
{
    public class DailyMailNotificationService : BackgroundService
    {
        private readonly ILogger<DailyMailNotificationService> _logger;

        public DailyMailNotificationService(ILogger<DailyMailNotificationService> logger)
        {
            _logger = logger;
        }

        SendMail sendmail = new();
       
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await sendmail.SendMailAsync("subject", "content", Environment.GetEnvironmentVariable("MAIL"));
                await Task.Delay(24*60*60*1000, stoppingToken);

            }
        }
    }
}
