
using System;
using System.Collections.Generic;

namespace InventoryAnalytics.Domain.Entities.Dwh.Facts;

public partial class FactEntregasProveedor
{
    public long EntregaKey { get; set; }

    public int FechaKey { get; set; }

    public int ProductoKey { get; set; }

    public int ProveedorKey { get; set; }

    public int? ProveedorEntregaKey { get; set; }

    public int CantidadEsperada { get; set; }

    public DateOnly? FechaEstimadaEntrega { get; set; }

    public string EstadoEntrega { get; set; }

}