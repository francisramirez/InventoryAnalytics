

namespace InventoryAnalytics.Domain.Entities.Db
{
    public class Sale
    {
        public int OrderNumber { get; set; }
        public int ProductId { get; set; }
        public  int CustomerId { get; set; }
        public int Total { get; set; }
    }
}
