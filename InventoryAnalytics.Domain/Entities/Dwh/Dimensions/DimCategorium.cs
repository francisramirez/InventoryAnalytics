
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAnalytics.Domain.Entities.Dwh.Dimensions;

[Table("DimCategoria", Schema = "Dimensiones")]

public partial class DimCategoria
{
    public int CategoriaKey { get; set; }

    public string NombreCategoria { get; set; }

    public string SubCategoria { get; set; }

    
}