using InventoryAnalytics.Api.Data.Context;
using InventoryAnalytics.Api.Data.Entities;
using InventoryAnalytics.Api.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventoryAnalytics.Api.Data.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly SupplierContext context;

        public SupplierRepository(SupplierContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<ViewSupplier>> GetAllSuppliersAsync()
        {
            return await this.context.Suppliers.ToArrayAsync();
        }

        public async Task<IEnumerable<ViewSupplierCategory>> GetAllSuppliersCategoriesAsync()
        {
            return await this.context.SupplierCategorys.ToArrayAsync();
        }
    }
}
