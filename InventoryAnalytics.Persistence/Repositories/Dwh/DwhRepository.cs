

using InventoryAnalytics.Application.Dtos.Apis;
using InventoryAnalytics.Application.Repositories;
using InventoryAnalytics.Application.Result;
using InventoryAnalytics.Domain.Entities.Dwh.Dimensions;
using InventoryAnalytics.Persistence.Repositories.Dwh.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Globalization;
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

        public async Task<ServiceResult> LoadDimsDataAsync(DimDtos dimDtos)
        {
            ServiceResult result = new ServiceResult();
            try
            {


                result = await CleanDimenssionTables();

                if (!result.IsSuccess)
                {
                    this._logger.LogError(result.Message);
                    // Enviar correo //
                    return result;
                }


                var inventoryData = await _csvInventoryFileReaderRepository.ReadFileAsync(dimDtos.fileDataInventory);



                // Obtener las categorias
                var categories = inventoryData.Select(ca => ca.Categoria.Trim())
                                             .Distinct()
                                             .Where(ca => !string.IsNullOrEmpty(ca))
                                             .Select(ca => new DimCategoria
                                             {
                                                 NombreCategoria = ca
                                             }).ToArray();


              
                await _dWHInventoryContext.DimCategoria.AddRangeAsync(categories);
                await _dWHInventoryContext.SaveChangesAsync();


                var products = inventoryData.Select(pr => new DimProducto
                {
                    NombreProducto = pr.NombreProducto.Trim(),
                    FechaCreacionDw = DateTime.Now,
                    ProductoIdOrigen = "CSV",
                    Marca = pr.Categoria,
                    CategoriaKey = categories.FirstOrDefault(ca => ca.NombreCategoria == pr.Categoria.Trim()).CategoriaKey
                }).ToArray();



                await _dWHInventoryContext.DimProductos.AddRangeAsync(products);


                var dataAlmacen = inventoryData.Select(al => al.CodigoAlmacen.Trim())
                                                            .Distinct()

                                                            .Select(al => new DimAlmacen
                                                            {
                                                                CodigoAlmacen = al,
                                                                NombreAlmacen = al,
                                                                FechaCreacionDw = DateTime.Now
                                                            }).ToArray();


                await _dWHInventoryContext.DimAlmacens.AddRangeAsync(dataAlmacen);



                // Dim Fecha
                var datafecha = inventoryData.Select(fe => fe.Fecha)
                                                            .Distinct()

                                                            .Select(fe => new DimFecha
                                                            {

                                                                Fecha = fe.Date,
                                                                Anio = fe.Year,
                                                                Dia = fe.Day,
                                                                Mes = fe.Month,
                                                                DiaNombre = fe.ToString("dddd", new CultureInfo("es-ES")),
                                                                EsFinSemana = (fe.DayOfWeek == DayOfWeek.Saturday || fe.DayOfWeek == DayOfWeek.Sunday),
                                                                FechaKey = Convert.ToInt32(fe.Date.ToString("yyyyMMdd")), //20251127
                                                                NombreMes = fe.ToString("MMMM", new CultureInfo("es-ES")),
                                                                Trimestre = (fe.Month - 1) / 3 + 1,
                                                                Semana = System.Globalization.ISOWeek.GetWeekOfYear(fe)
                                                            }).ToArray();



              

                await _dWHInventoryContext.DimFechas.AddRangeAsync(datafecha);



                // Carga del fact //





                await _dWHInventoryContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error cargando la dim de suplidores...");
                //enviar notificacion.
            }

            return result;
        }

        private async Task<ServiceResult> CleanDimenssionTables()
        {
            ServiceResult result = null;

            try
            {
                await _dWHInventoryContext.DimProductos.ExecuteDeleteAsync();
                await _dWHInventoryContext.DimCategoria.ExecuteDeleteAsync();
                await _dWHInventoryContext.DimAlmacens.ExecuteDeleteAsync();
                await _dWHInventoryContext.DimFechas.ExecuteDeleteAsync();


                _dWHInventoryContext.SaveChangesAsync();

                result = new ServiceResult() { IsSuccess= true, Message="La data de las dimensiones fueron limpiadas."};

            }
            catch (Exception ex)
            {

                result = new ServiceResult()
                {
                    IsSuccess = false,
                    Message = $"Error limpiando: {ex.Message}"
                };
            }

            return result;

        }
    }
}
