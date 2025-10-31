


namespace InventoryAnalytics.Persistence.Repositories.Api
{
    using InventoryAnalytics.Application.Repositories;
    using InventoryAnalytics.Domain.Entities.Api;

    public class SupplierApiRepository : ISupplierApiRepository
    {
        public Task<IEnumerable<Supplier>> GetSuppliersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
