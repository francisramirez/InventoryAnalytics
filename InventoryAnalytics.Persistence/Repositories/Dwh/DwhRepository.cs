

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
        private readonly ILogger<DWHInventoryContext> _logger;

        public DwhRepository(DWHInventoryContext dWHInventoryContext,
             ILogger<DWHInventoryContext> logger)
        {
            _dWHInventoryContext = dWHInventoryContext;
            _logger = logger;
        }

        public async Task<ServiceResult> LoadDimsData(DimDtos dimDtos)
        {
            ServiceResult result = new ServiceResult();
            try
            {


                var datosSuppliers = dimDtos.SupplierCategoryDtos.Where(cd => cd.SupplierCategoryID != 1)
                                                                 .Select(cd => new DimSupplierCategory()
                                                                 {
                                                                     SupplierCategoryName = cd.SupplierCategoryName.Trim(),
                                                                     SupplierID = cd.SupplierID,
                                                                     SupplierName = Convert.ToChar(cd.SupplierName.Trim())
                                                                 }).ToArray();


                var queryInvtario = (from inv in dimDtos.Inventories
                                     join sup in dimDtos.SupplierCategoryDtos on inv.SupplierId equals sup.SupplierID
                                     select new DimInventarioDiario()
                                     {
                                         StockItemID = inv.StockItemId,
                                         StockItemName = inv.StockItemName,
                                         SupplierName = sup.SupplierName
                                     }).ToList();




                await _dWHInventoryContext.DimInventarioDiarios.AddRangeAsync(queryInvtario);

                await _dWHInventoryContext.DimSupplierCategories.AddRangeAsync(datosSuppliers);



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
