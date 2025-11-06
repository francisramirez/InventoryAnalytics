
using Microsoft.EntityFrameworkCore;
using InventoryAnalytics.Api.Data.Context;
using InventoryAnalytics.Api.Data.Interface;
using InventoryAnalytics.Api.Data.Repository;

namespace InventoryAnalytics.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<SupplierContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SupplierDatabase")));

            builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
