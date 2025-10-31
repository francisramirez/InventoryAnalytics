

namespace InventoryAnalytics.Domain.Entities.Csv
{
    public class InventarioDiario
    {
        /// <summary>
        /// Fecha del registro (día del inventario).
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Código del almacén donde se encuentra el producto.
        /// </summary>
        public string CodigoAlmacen { get; set; } = string.Empty;

        /// <summary>
        /// Código del producto.
        /// </summary>
        public string CodigoProducto { get; set; } = string.Empty;

        /// <summary>
        /// Nombre descriptivo del producto.
        /// </summary>
        public string NombreProducto { get; set; } = string.Empty;

        /// <summary>
        /// Categoría del producto.
        /// </summary>
        public string Categoria { get; set; } = string.Empty;

        /// <summary>
        /// Cantidad de unidades al inicio del día.
        /// </summary>
        public int StockInicial { get; set; }

        /// <summary>
        /// Cantidad de unidades que entraron durante el día.
        /// </summary>
        public int Entradas { get; set; }

        /// <summary>
        /// Cantidad de unidades que salieron durante el día.
        /// </summary>
        public int Salidas { get; set; }

        /// <summary>
        /// Cantidad de unidades restantes al final del día.
        /// </summary>
        public int StockFinal { get; set; }

        /// <summary>
        /// Costo promedio por unidad del producto.
        /// </summary>
        public decimal CostoPromedio { get; set; }

        /// <summary>
        /// Valor total del inventario (StockFinal × CostoPromedio).
        /// </summary>
        public decimal ValorInventario { get; set; }

        /// <summary>
        /// Devuelve una representación legible del registro.
        /// </summary>
        public override string ToString()
        {
            return $"{Fecha:yyyy-MM-dd} | {CodigoAlmacen} | {CodigoProducto} | Stock: {StockFinal} | Valor: {ValorInventario:C2}";
        }
    }
}
