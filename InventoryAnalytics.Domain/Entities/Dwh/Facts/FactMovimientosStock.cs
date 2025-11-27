
using System;
using System.Collections.Generic;

namespace InventoryAnalytics.Domain.Entities.Dwh.Facts;

public partial class FactMovimientosStock
{
    public long MovimientoKey { get; set; }

    public int ProductoKey { get; set; }

    public int FechaKey { get; set; }

    public int AlmacenKey { get; set; }

    public string TipoMovimiento { get; set; }

    public int Cantidad { get; set; }


}