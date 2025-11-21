

using InventoryAnalytics.Application.Dtos.Apis;
using InventoryAnalytics.Application.Result;

namespace InventoryAnalytics.Application.Repositories
{
    public interface IDwhRepository
    {
        Task<ServiceResult> LoadDimsData(DimDtos dimDtos);
    }
}
