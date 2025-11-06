
namespace InventoryAnalytics.Application.Services
{
    using InventoryAnalytics.Application.Interfaces;
    using InventoryAnalytics.Application.Repositories;
    using InventoryAnalytics.Application.Result;
    public class InventoryHandlerService : IInventoryHandlerService
    {
        private readonly IInventoryRepository inventoryRepository;
        private readonly ISupplierApiRepository supplierApiRepository;
        private readonly ICsvInventoryFileReaderRepository csvInventoryFileRepository;

        public InventoryHandlerService(IInventoryRepository inventoryRepository, 
                                       ISupplierApiRepository supplierApiRepository,
                                       ICsvInventoryFileReaderRepository csvInventoryFileRepository) 
        {
            this.inventoryRepository = inventoryRepository;
            this.supplierApiRepository = supplierApiRepository;
            this.csvInventoryFileRepository = csvInventoryFileRepository;
        }
        /// <summary>
        ///   Processes inventory data asynchronously.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ServiceResult> ProcessInventoryDataAsync()
        {

            // Extraer la data
            var inventardiario = await this.csvInventoryFileRepository
                                           .ReadFileAsync(@"D:\\ITLA\\Materias\\Big Data\\datos inventarios");

            var suplliers = await this.supplierApiRepository.GetSuppliersAsync();


            // procesar para dwh //

            throw new NotImplementedException();
        }
    }
}
