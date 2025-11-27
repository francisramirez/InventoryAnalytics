
using System;
using System.Collections.Generic;

namespace InventoryAnalytics.Domain.Entities.Dwh.Facts;

public partial class FactInventarioHistorico
{
    public long InventarioHistoricoKey { get; set; }

    public int ProductoKey { get; set; }

    public int FechaKey { get; set; }

    public int? StockPromedio { get; set; }

    public int? VentaTotalDia { get; set; }

    public decimal? Rotacion { get; set; }

    public int? StockCritico { get; set; }


}