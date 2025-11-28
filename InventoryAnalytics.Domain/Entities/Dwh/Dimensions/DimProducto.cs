
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace InventoryAnalytics.Domain.Entities.Dwh.Dimensions;

[Table("DimProducto", Schema = "Dimensiones")]
public partial class DimProducto
{
    [Key]
    public int ProductoKey { get; set; }

    public string ProductoIdOrigen { get; set; }

    public string NombreProducto { get; set; }

    public int? CategoriaKey { get; set; }

    public string Marca { get; set; }

    public string UnidadMedida { get; set; }

    public string EstadoProducto { get; set; }

    public DateTime FechaCreacionDw { get; set; }

  
}