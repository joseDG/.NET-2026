
using Api.Services.Authentication;
using Api.Services.Productos;
using Microsoft.AspNetCore.SignalR;

namespace Api;

public class ServerNotifier : BackgroundService
{
    
    private static readonly TimeSpan Periodo = TimeSpan.FromSeconds(5);
    private readonly IHubContext<NotificationHub, INotificationClient> contextSR;
    private readonly IServiceScopeFactory scopeFactory;
    private readonly ILogger<ServerNotifier> logger;

  public ServerNotifier(IHubContext<NotificationHub, INotificationClient> contextSR, ILogger<ServerNotifier> logger, IServiceScopeFactory scopeFactory)
  {
    this.contextSR = contextSR;
    this.logger = logger;
    this.scopeFactory = scopeFactory;
  }

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(Periodo);
        while (!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
        {
            var dateTime = DateTime.Now;
            logger.LogInformation($"Ejecutando {nameof(ServerNotifier)} {dateTime}");

            //Agregando nuevas funcionalidades
            using var scope = scopeFactory.CreateScope();
            var authenticationService = scope.ServiceProvider.GetRequiredService<IAuthenticationService>();
            var productoService = scope.ServiceProvider.GetService<IProductoService>();

            var usuario = await authenticationService.GetUserByEmail("vaxitest@gmail.com");
            
            if(usuario is not null)
            {
                
                var productos = await productoService!.GetProductoByNombre("A");
                var random = new Random();
                var indiceRandom = random.Next(productos.Count);
                var producto = productos[indiceRandom];

                await contextSR.Clients.User(usuario.FirebaseId!)
                    .RecibeNotification($@"Producto del dia para comprar: {producto.Nombre} - Paga solo {producto.Precio}");                
            }


        }
    }
}
