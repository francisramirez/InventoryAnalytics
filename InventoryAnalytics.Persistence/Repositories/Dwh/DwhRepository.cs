

using InventoryAnalytics.Application.Dtos.Apis;
using InventoryAnalytics.Application.Repositories;
using InventoryAnalytics.Application.Result;
using InventoryAnalytics.Persistence.Repositories.Dwh.Context;
using Microsoft.Extensions.Logging;

using InventoryAnalytics.Domain.Entities.Dwh.Dimensions;
using Microsoft.EntityFrameworkCore;
namespace InventoryAnalytics.Persistence.Repositories.Dwh
{
    public class DwhRepository : IDwhRepository
    {
        private readonly DWHInventoryContext _dWHInventoryContext;
        private readonly ICsvInventoryFileReaderRepository _csvInventoryFileReaderRepository;
        private readonly ILogger<DWHInventoryContext> _logger;

        public DwhRepository(DWHInventoryContext dWHInventoryContext,
            ICsvInventoryFileReaderRepository csvInventoryFileReaderRepository,
             ILogger<DWHInventoryContext> logger)
        {
            _dWHInventoryContext = dWHInventoryContext;
            _csvInventoryFileReaderRepository = csvInventoryFileReaderRepository;
            _logger = logger;
        }

        public async Task<ServiceResult> LoadDimsData(DimDtos dimDtos)
        {
            ServiceResult result = new ServiceResult();
            try
            {

                var inventoryData = await _csvInventoryFileReaderRepository.ReadFileAsync(dimDtos.fileDataInventory);



                // Obtener las categorias
                var categories = inventoryData.Select(ca => ca.Categoria.Trim())
                                             .Distinct()
                                             .Where(ca => !string.IsNullOrEmpty(ca))
                                             .Select(ca => new DimCategoria
                                             {
                                                 NombreCategoria = ca
                                             }).ToArray();



                _dWHInventoryContext.DimCategoria.AddRange(categories);


                var products = inventoryData.Select(pr => new DimProducto
                {
                    NombreProducto = pr.NombreProducto.Trim(),  
                    CategoriaKey = categories.FirstOrDefault(ca => ca.NombreCategoria == pr.Categoria.Trim()).CategoriaKey
                }).ToArray();



                await _dWHInventoryContext.DimProductos.AddRangeAsync(products);


                var dataAlmacen = inventoryData.Select(al => al.CodigoAlmacen.Trim())
                                                            .Distinct()
                                                         
                                                            .Select(al => new DimAlmacen
                                                            {
                                                                 CodigoAlmacen = al,  
                                                            }).ToArray();


                await _dWHInventoryContext.DimAlmacens.AddRangeAsync(dataAlmacen);



                var datafecha = inventoryData.Select(fe => fe.Fecha)
                                                            .Distinct()
                                                         
                                                            .Select(fe => new DimFecha
                                                            {
                                                                Fecha = fe.Date, 
                                                                Anio = fe.Year, 
                                                                Dia = fe.Day, 
                                                                Mes = fe.Month, 
                                                                DiaNombre = fe.ToString("dddd"), 
                                                                EsFinSemana = (fe.DayOfWeek == DayOfWeek.Saturday || fe.DayOfWeek == DayOfWeek.Sunday), 
                                                                FechaKey = fe.Year * 10000 + fe.Month * 100 + fe.Day, 
                                                                NombreMes = fe.ToString("MMMM"),
                                                                Trimestre = (fe.Month - 1) / 3 + 1,
                                                                Semana = System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(fe, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)
                                                            }).ToArray();


                 await _dWHInventoryContext.DimFechas.AddRangeAsync(datafecha);




                await _dWHInventoryContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error cargando la dim de suplidores...");
                //enviar notificacion.
            }

            return result;
        }
    }
}
