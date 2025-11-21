using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAnalytics.Api.Data.Entities
{

    [Table("ViewSuppliers", Schema = "Purchasing")]
    public class ViewSupplier
    {
        [Key]
        public int SupplierId { get; set; }

        public string? SupplierName { get; set; }
    }
}
