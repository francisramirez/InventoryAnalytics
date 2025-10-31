
namespace InventoryAnalytics.Application.Repositories
{
    using InventoryAnalytics.Domain.Entities.Csv;
    public interface IInventoryRepository
    {
        Task<IEnumerable<InventarioDiario>> GetInventoryDataAsync();
    }
}
