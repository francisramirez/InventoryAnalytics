
using System;
using System.Collections.Generic;

namespace InventoryAnalytics.Domain.Entities.Dwh.Facts;

public partial class FactVenta
{
    public long VentaKey { get; set; }

    public int ProductoKey { get; set; }

    public int FechaKey { get; set; }

    public int CantidadVendida { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal? MontoVenta { get; set; }

    public string ClienteId { get; set; }

 
}