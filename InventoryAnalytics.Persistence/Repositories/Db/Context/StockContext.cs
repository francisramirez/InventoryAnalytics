

using InventoryAnalytics.Domain.Entities.Db;
using Microsoft.EntityFrameworkCore;

namespace InventoryAnalytics.Persistence.Repositories.Db.Context
{
    public class StockContext : DbContext
    {
        public StockContext(DbContextOptions<StockContext> options) :base(options)
        {
            
        }
        public DbSet<Inventory> Inventories { get; set; }
    }
}
