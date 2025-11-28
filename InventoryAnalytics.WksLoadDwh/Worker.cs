using InventoryAnalytics.Application.Interfaces;
using InventoryAnalytics.Application.Repositories;
using InventoryAnalytics.Application.Services;
using InventoryAnalytics.Persistence.Repositories.Api;
using InventoryAnalytics.Persistence.Repositories.Csv;
using InventoryAnalytics.Persistence.Repositories.Db;
using InventoryAnalytics.Persistence.Repositories.Dwh;
using InventoryAnalytics.Persistence.Repositories.Dwh.Context;

namespace InventoryAnalytics.WksLoadDwh
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider serviceProvider;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            this.serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {


            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    try
                    {

                        using (var scope = this.serviceProvider.CreateScope())
                        {
                            IInventoryHandlerService inventoryHandlerService = GetServices(scope);

                            await inventoryHandlerService.ProcessInventoryDataAsync();

                            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                        }

                    }
                    catch (Exception)
                    {

                        _logger.LogError("Error procesando los datos.");
                    }


                }
                await Task.Delay(5000, stoppingToken);
            }
        }

        private static IInventoryHandlerService GetServices(IServiceScope scope)
        {
            var db = scope.ServiceProvider.GetRequiredService<DWHInventoryContext>();
            var csvRepo = scope.ServiceProvider.GetRequiredService<ICsvInventoryFileReaderRepository>();
            var dwhRepo = scope.ServiceProvider.GetRequiredService<IDwhRepository>();
            var inventoryHandlerService = scope.ServiceProvider.GetRequiredService<IInventoryHandlerService>();
            return inventoryHandlerService;
        }
    }
}
