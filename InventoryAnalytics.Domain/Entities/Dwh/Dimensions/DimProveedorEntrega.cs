
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAnalytics.Domain.Entities.Dwh.Dimensions;

[Table("DimProveedorEntrega", Schema = "Dimensiones")]
public partial class DimProveedorEntrega
{
    [Key]
    public int ProveedorEntregaKey { get; set; }

    public string ProveedorIdOrigen { get; set; }

    public int? TiempoEntregaPromedioDias { get; set; }

    public string TipoEntrega { get; set; }

    public DateTime FechaCreacionDw { get; set; }

 }