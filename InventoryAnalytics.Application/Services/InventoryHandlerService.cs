
namespace InventoryAnalytics.Application.Services
{
    using InventoryAnalytics.Application.Dtos.Apis;
    using InventoryAnalytics.Application.Interfaces;
    using InventoryAnalytics.Application.Repositories;
    using InventoryAnalytics.Application.Result;
    public class InventoryHandlerService : IInventoryHandlerService
    {
        private readonly IInventoryRepository inventoryRepository;
        private readonly ISupplierApiRepository supplierApiRepository;
        private readonly ICsvInventoryFileReaderRepository csvInventoryFileRepository;
        private readonly IDwhRepository dwhRepository;

        public InventoryHandlerService(IInventoryRepository inventoryRepository, 
                                       ISupplierApiRepository supplierApiRepository,
                                       ICsvInventoryFileReaderRepository csvInventoryFileRepository,
                                       IDwhRepository dwhRepository) 
        {
            this.inventoryRepository = inventoryRepository;
            this.supplierApiRepository = supplierApiRepository;
            this.csvInventoryFileRepository = csvInventoryFileRepository;
            this.dwhRepository = dwhRepository;
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

            DimDtos dimDtos = new DimDtos();

            dimDtos.Inventories = inventardiario;
            dimDtos.SupplierCategoryDtos = suplliers;
            var result this.dwhRepository.LoadDimsData(dimDtos);

            if (result.Success)
            {
                this.dwhRepository.loadfacts();
            }


            throw new NotImplementedException();
        }
    }
}
