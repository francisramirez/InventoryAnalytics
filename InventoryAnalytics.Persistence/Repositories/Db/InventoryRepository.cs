



namespace InventoryAnalytics.Persistence.Repositories.Db
{
    using InventoryAnalytics.Application.Repositories;
    using InventoryAnalytics.Domain.Entities.Db;
    public class InventoryRepository : IInventoryRepository
    {
        public Task<IEnumerable<Inventory>> GetInventoryDataAsync()
        {
            throw new NotImplementedException();
        }
    }
}
