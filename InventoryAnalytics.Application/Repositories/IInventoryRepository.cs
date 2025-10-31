
namespace InventoryAnalytics.Application.Repositories
{
    
    using InventoryAnalytics.Domain.Entities.Db;

    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> GetInventoryDataAsync();
    }
}
