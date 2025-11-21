

using InventoryAnalytics.Domain.Entities.Dwh.Dimensions;
using Microsoft.EntityFrameworkCore;

namespace InventoryAnalytics.Persistence.Repositories.Dwh.Context
{
    public class DWHInventoryContext : DbContext
    {
        public DWHInventoryContext(DbContextOptions<DWHInventoryContext> options) : base(options)
        {

        }
        public DbSet<DimProduct> DimProducts { get; set; }
        public DbSet<DimSupplierCategory> DimSupplierCategories { get; set; }
        public DbSet<DimInventarioDiario> DimInventarioDiarios { get; set; }

    }
}
