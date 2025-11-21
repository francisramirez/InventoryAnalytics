

namespace InventoryAnalytics.Domain.Entities.Dwh.Dimensions
{
    public class DimProduct
    {
        public int ProductKey { get;set; }
        public int ProductId { get; set; }

        public string Name { get;set; }
        public decimal UnitPrice { get; set; }
        public string CategoryName { get; set; }

    }
}
