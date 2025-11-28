
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAnalytics.Domain.Entities.Dwh.Dimensions;
[Table("DimProveedor", Schema ="Dimensiones")]
public partial class DimProveedor
{
    [Key]
    public int ProveedorKey { get; set; }

    public string ProveedorIdOrigen { get; set; }

    public string NombreProveedor { get; set; }

    public string TipoProveedor { get; set; }

    public string Pais { get; set; }

    public string Telefono { get; set; }

    public DateTime FechaCreacionDw { get; set; }

}