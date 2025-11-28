

using InventoryAnalytics.Domain.Entities.Dwh.Dimensions;
using InventoryAnalytics.Domain.Entities.Dwh.Facts;
using Microsoft.EntityFrameworkCore;

namespace InventoryAnalytics.Persistence.Repositories.Dwh.Context
{
    public partial class DWHInventoryContext : DbContext
    {
        public DWHInventoryContext(DbContextOptions<DWHInventoryContext> options) : base(options)
        {

        }
       /// public DbSet<DimProduct> DimProducts { get; set; }
      //  public DbSet<DimSupplierCategory> DimSupplierCategories { get; set; }
       // public DbSet<DimInventarioDiario> DimInventarioDiarios { get; set; }

        public DbSet<DimAlmacen> DimAlmacens { get; set; }

        public DbSet<DimCategoria> DimCategoria { get; set; }

        public DbSet<DimFecha> DimFechas { get; set; }

        public DbSet<DimProducto> DimProductos { get; set; }

        public DbSet<DimProveedor> DimProveedors { get; set; }

        public DbSet<DimProveedorEntrega> DimProveedorEntregas { get; set; }

       // public DbSet<FactEntregasProveedor> FactEntregasProveedors { get; set; }

        //public DbSet<FactInventarioDiario> FactInventarioDiarios { get; set; }

        //public DbSet<FactInventarioHistorico> FactInventarioHistoricos { get; set; }

        //public DbSet<FactMovimientosStock> FactMovimientosStocks { get; set; }

        //public DbSet<FactVenta> FactVentas { get; set; }


    }
}
