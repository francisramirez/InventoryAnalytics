

using InventoryAnalytics.Domain.Entities.Csv;
using InventoryAnalytics.Domain.Entities.Db;

namespace InventoryAnalytics.Application.Dtos.Apis
{
    public class DimDtos
    {
        public List<SupplierCategoryDto>  SupplierCategoryDtos { get; set; }
        public List<Inventory> Inventories { get; set; }
    }
}
