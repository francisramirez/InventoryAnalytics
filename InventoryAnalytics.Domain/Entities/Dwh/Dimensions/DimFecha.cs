
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace InventoryAnalytics.Domain.Entities.Dwh.Dimensions;

[Table("DimFecha", Schema = "Dimensiones")]
public partial class DimFecha
{
    [Key]
    public int FechaKey { get; set; }

    public DateTime Fecha { get; set; }

    public int Anio { get; set; }

    public int Mes { get; set; }

    public int Dia { get; set; }

    public string NombreMes { get; set; }

    public int Trimestre { get; set; }

    public int Semana { get; set; }

    public string DiaNombre { get; set; }

    public bool EsFinSemana { get; set; }

  
}