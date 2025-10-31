



namespace InventoryAnalytics.Application.Interfaces
{
    using InventoryAnalytics.Application.Result;
    public interface IInventoryHandlerService
    {
        Task<ServiceResult> ProcessInventoryDataAsync();
    }
}
