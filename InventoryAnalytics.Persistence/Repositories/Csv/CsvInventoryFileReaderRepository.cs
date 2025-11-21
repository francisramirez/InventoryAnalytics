



namespace InventoryAnalytics.Persistence.Repositories.Csv
{
    using CsvHelper;
    using InventoryAnalytics.Application.Repositories;
    using InventoryAnalytics.Domain.Entities.Csv;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public sealed class CsvInventoryFileReaderRepository : ICsvInventoryFileReaderRepository
    {
        private readonly string? _pathFile;
        private readonly IConfiguration _configuration;
        private readonly ILogger<CsvInventoryFileReaderRepository> _logger;

        public CsvInventoryFileReaderRepository(IConfiguration configuration, 
                                                ILogger<CsvInventoryFileReaderRepository> logger) 
        {
            _configuration = configuration;
            _logger = logger;
            _pathFile = _configuration["InventoryCsvFilePath"];
        }
        public async Task<IEnumerable<InventarioDiario>> ReadFileAsync(string filePath)
        {
           List<InventarioDiario>? inventoryData = new List<InventarioDiario>();

            _logger.LogInformation("Reading CSV file at path: {FilePath}", filePath);

            try
            {
                
                using var reader = new StreamReader(filePath);
                using var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture);
               
                await foreach (var record in csv.GetRecordsAsync<InventarioDiario>())
                {
                    inventoryData.Add(record);
                }
                
            }
            catch (Exception)
            {
                inventoryData = null;
                _logger.LogError("Error reading CSV file at path: {FilePath}", filePath);
            }
            return inventoryData!;
        }
    }
}
