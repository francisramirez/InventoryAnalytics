
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAnalytics.Domain.Entities.Dwh.Dimensions;

[Table("DimAlmacen", Schema = "Dimensiones")]
public partial class DimAlmacen
{

    public int AlmacenKey { get; set; }

    public string CodigoAlmacen { get; set; }

    public string AlmacenIdOrigen { get; set; }

    public string NombreAlmacen { get; set; }

    public string Ubicacion { get; set; }

    public string TipoAlmacen { get; set; }

    public DateTime FechaCreacionDw { get; set; }

  }