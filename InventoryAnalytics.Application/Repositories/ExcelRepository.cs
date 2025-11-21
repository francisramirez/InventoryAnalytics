

using InventoryAnalytics.Domain.Entities.Excel;
using InventoryAnalytics.Domain.Repository;

namespace InventoryAnalytics.Application.Repositories
{
    public interface IExcelRepository : IFileReaderRepository<ExcelModel>
    {
        // metodos propio excel
    }
}
