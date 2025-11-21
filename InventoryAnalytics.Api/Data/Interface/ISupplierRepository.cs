using InventoryAnalytics.Api.Data.Entities;

namespace InventoryAnalytics.Api.Data.Interface
{
    public interface ISupplierRepository
    {
        public Task<IEnumerable<ViewSupplier>> GetAllSuppliersAsync();
        public Task<IEnumerable<ViewSupplierCategory>> GetAllSuppliersCategoriesAsync();
    }
}
