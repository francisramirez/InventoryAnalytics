
using InventoryAnalytics.Domain.Entities.Api;

namespace InventoryAnalytics.Application.Repositories
{
    public interface ISupplierApiRepository
    {
        Task<IEnumerable<Supplier>> GetSuppliersAsync();
    }
}
