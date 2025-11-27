
using System;
using System.Collections.Generic;

namespace InventoryAnalytics.Domain.Entities.Dwh.Facts;

public partial class FactInventarioDiario
{
    public long InventarioDiarioKey { get; set; }

    public int ProductoKey { get; set; }

    public int FechaKey { get; set; }

    public int AlmacenKey { get; set; }

    public int? StockInicial { get; set; }

    public int? StockFinal { get; set; }

    public int? StockCritico { get; set; }

    public decimal? ValorUnitario { get; set; }

    public decimal? ValorInventario { get; set; }

   
}