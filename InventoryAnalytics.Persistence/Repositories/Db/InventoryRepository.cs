

using InventoryAnalytics.Application.Repositories;
using InventoryAnalytics.Domain.Entities.Csv;

namespace InventoryAnalytics.Persistence.Repositories.Db
{
    public class InventoryRepository : IInventoryRepository
    {
        public Task<IEnumerable<InventarioDiario>> GetInventoryDataAsync()
        {
            throw new NotImplementedException();
        }
    }
}
