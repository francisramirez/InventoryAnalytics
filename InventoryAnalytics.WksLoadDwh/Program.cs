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

           
            //registrar las dependencias del DwhRepository

            builder.Services.AddDbContext<DWHInventoryContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DWHInventoryConnString")));
            builder.Services.AddScoped<ICsvInventoryFileReaderRepository, CsvInventoryFileReaderRepository>();
            builder.Services.AddScoped<IDwhRepository, DwhRepository>();

            //registrar dependencias de InventoryHandlerService
            builder.Services.AddScoped<IInventoryHandlerService, InventoryHandlerService>();


            builder.Services.AddHostedService<Worker>();


            var host = builder.Build();


            host.Run();
        }
    }
}