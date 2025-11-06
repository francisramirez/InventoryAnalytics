
namespace InventoryAnalytics.Application.Repositories
{
    using InventoryAnalytics.Domain.Repository;
    using InventoryAnalytics.Domain.Entities.Csv;
    public interface ICsvInventoryFileReaderRepository : IFileReaderRepository<InventarioDiario>
    {
         // los metodos para las operaciones de los csv's.
    }
 
}
