



namespace InventoryAnalytics.Persistence.Repositories.Db
{
    using InventoryAnalytics.Application.Repositories;
    using InventoryAnalytics.Domain.Entities.Db;
    using InventoryAnalytics.Persistence.Repositories.Db.Context;
    using Microsoft.EntityFrameworkCore;

    public class InventoryRepository : IInventoryRepository
    {
        private readonly StockContext context;

        public InventoryRepository(StockContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Inventory>> GetInventoryDataAsync()
        {
            return await this.context.Inventories.ToListAsync();
        }
    }
}
