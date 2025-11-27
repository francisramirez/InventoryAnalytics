using InventoryAnalytics.Application.Interfaces;
using InventoryAnalytics.Application.Repositories;
using InventoryAnalytics.Application.Services;
using InventoryAnalytics.Persistence.Repositories.Csv;
using InventoryAnalytics.Persistence.Repositories.Dwh;
using InventoryAnalytics.Persistence.Repositories.Dwh.Context;
using Microsoft.EntityFrameworkCore;

namespace InventoryAnalytics.WksLoadDwh
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            builder.Services.AddHostedService<Worker>();

            //registrar las dependencias del DwhRepository

            builder.Services.AddDbContextPool<DWHInventoryContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DWHInventoryConnString")));
            builder.Services.AddScoped<ICsvInventoryFileReaderRepository, CsvInventoryFileReaderRepository>();
            builder.Services.AddScoped<IDwhRepository, DwhRepository>();

            //registrar dependencias de InventoryHandlerService
            builder.Services.AddTransient<IInventoryHandlerService, InventoryHandlerService>();

            var host = builder.Build();


            host.Run();
        }
    }
}