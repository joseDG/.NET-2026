using Microsoft.AspNetCore.SignalR;

namespace FireBaseApi
{
    public class ServerNotifier : BackgroundService
    {

        private readonly IHubContext<NotificationHub, INotificationClient> contextSR;
        private static readonly TimeSpan Periodo = TimeSpan.FromSeconds(5);
        private readonly ILogger<ServerNotifier> logger;


        public ServerNotifier(IHubContext<NotificationHub, INotificationClient> contextSr, ILogger<ServerNotifier> logger)
        {
            this.contextSR = contextSr;
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(Periodo);
            while (!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
            {
                var dateTime = DateTime.Now;
                logger.LogInformation("Ejecutando {nameof(ServerNotifier)} {dateTime}");

                await contextSR.Clients.All.RecibeNotification($"Servidor time = {dateTime}");
            }
        }
    }
}
