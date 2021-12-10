using DataAccess.Data;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MailService
{
    public class DailyMailNotificationService : BackgroundService
    {
        private readonly ILogger<DailyMailNotificationService> _logger;
        private readonly IReservationData _reservationData;

        public DailyMailNotificationService(ILogger<DailyMailNotificationService> logger, IReservationData reservationData)
        {
            _logger = logger;
            _reservationData = reservationData;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var reservations = await _reservationData.GetReservations();
                SendMail sendmail = new();
                foreach (var reservation in reservations)
                {
                    if (reservation.StartDate.Date == DateTime.Today.AddDays(1))
                    {
                        await sendmail.SendMailAsync("Opkommende reservation", "Medborgerhuset er reserveret i morgen", Environment.GetEnvironmentVariable("MAIL"));
                    }
                }
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                await Task.Delay(24 * 60 * 60 * 1000, stoppingToken);
            }
        }
    }
}
