

using InventoryAnalytics.Application.Repositories;
using InventoryAnalytics.Domain.Entities.Excel;

namespace InventoryAnalytics.Persistence.Repositories.Excel
{
    public class ExcelRepository : IExcelRepository
    {
        public Task<IEnumerable<ExcelModel>> ReadFileAsync(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
