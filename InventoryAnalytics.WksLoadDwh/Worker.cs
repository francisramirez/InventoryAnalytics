using InventoryAnalytics.Application.Interfaces;
using InventoryAnalytics.Application.Services;
using InventoryAnalytics.Persistence.Repositories.Api;
using InventoryAnalytics.Persistence.Repositories.Csv;
using InventoryAnalytics.Persistence.Repositories.Db;
using InventoryAnalytics.Persistence.Repositories.Dwh;

namespace InventoryAnalytics.WksLoadDwh
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IInventoryHandlerService _inventoryHandlerService;

        public Worker(ILogger<Worker> logger, IInventoryHandlerService inventoryHandlerService)
        {
            _logger = logger;
            _inventoryHandlerService = inventoryHandlerService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

          
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
