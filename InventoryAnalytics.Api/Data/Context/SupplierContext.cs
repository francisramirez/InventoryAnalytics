using Microsoft.EntityFrameworkCore;
using System.Data;
using InventoryAnalytics.Api.Data.Entities;
namespace InventoryAnalytics.Api.Data.Context
{
    public class SupplierContext : DbContext
    {
        public SupplierContext(DbContextOptions<SupplierContext> options) : base(options)
        {
            
        }
        public DbSet<ViewSupplier> Suppliers { get; set; }
        public DbSet<ViewSupplierCategory> SupplierCategorys { get; set; }

    }
}
