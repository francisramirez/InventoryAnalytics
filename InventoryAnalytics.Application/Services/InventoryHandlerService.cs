
namespace InventoryAnalytics.Application.Services
{
    using InventoryAnalytics.Application.Dtos.Apis;
    using InventoryAnalytics.Application.Interfaces;
    using InventoryAnalytics.Application.Repositories;
    using InventoryAnalytics.Application.Result;
    using Microsoft.Extensions.Configuration;

    public class InventoryHandlerService : IInventoryHandlerService
    {
        //private readonly IInventoryRepository inventoryRepository;
        //private readonly ISupplierApiRepository supplierApiRepository;
        //private readonly ICsvInventoryFileReaderRepository csvInventoryFileRepository;
        //IInventoryRepository inventoryRepository,
        //                               ISupplierApiRepository supplierApiRepository,
        //                               ICsvInventoryFileReaderRepository csvInventoryFileRepository,
        private readonly IDwhRepository _dwhRepository;
        private readonly IConfiguration _configuration;

        public InventoryHandlerService(IDwhRepository dwhRepository,
                                       IConfiguration configuration)
        {
            //this.inventoryRepository = inventoryRepository;
            //this.supplierApiRepository = supplierApiRepository;
            //this.csvInventoryFileRepository = csvInventoryFileRepository;
            _dwhRepository = dwhRepository;
            _configuration = configuration;
        }
        /// <summary>
        ///   Processes inventory data asynchronously.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ServiceResult> ProcessInventoryDataAsync()
        {
            ServiceResult serviceResult = new ServiceResult();

            try
            {
                DimDtos dimDtos = new DimDtos();

                dimDtos.fileDataInventory = _configuration["ConnectionStrings:CsvPathString"];

                serviceResult = await _dwhRepository.LoadDimsDataAsync(dimDtos);
            }
            catch (Exception ex)
            {
                serviceResult.IsSuccess = false;

                serviceResult.Message = ex.Message;

                //Loggerar y enviar correo //

            }
            return serviceResult;


        }
    }
}
