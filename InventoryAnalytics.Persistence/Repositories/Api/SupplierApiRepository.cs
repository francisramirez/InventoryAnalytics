


namespace InventoryAnalytics.Persistence.Repositories.Api
{
    using InventoryAnalytics.Application.Repositories;
    using InventoryAnalytics.Domain.Entities.Api;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System.Net.Http.Json;

    public class SupplierApiRepository : ISupplierApiRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<SupplierApiRepository> _logger;
        private readonly IConfiguration _configuration;
        private string baseUrl = string.Empty;

        public SupplierApiRepository(IHttpClientFactory clientFactory,
                                     ILogger<SupplierApiRepository> logger,
                                     IConfiguration configuration
                                     )
        {
            _clientFactory = clientFactory;
            _logger = logger;
            _configuration = configuration;
            baseUrl = _configuration["ApiConfig:BaseUrl"] ?? string.Empty;
        }
        public async Task<IEnumerable<Supplier>> GetSuppliersAsync()
        {

            List<Supplier> suppliers = new List<Supplier>();


            try
            {
            

                using var client = _clientFactory.CreateClient("SupplierApiClient");
                client.BaseAddress = new Uri(baseUrl);

                using var response = await client.GetAsync("api/SupplierApi/GetAllSuppliers");

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadFromJsonAsync<IEnumerable<Supplier>>();
                    if (apiResponse != null)
                    {
                        suppliers = apiResponse.ToList();
                    }
                }
                else
                {
                    _logger.LogError("Failed to fetch suppliers. Status Code: {StatusCode}", response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                suppliers = null!;
                _logger.LogError(ex, "Error fetching suppliers from API");

            }
            return suppliers!;


        }
    }
}
