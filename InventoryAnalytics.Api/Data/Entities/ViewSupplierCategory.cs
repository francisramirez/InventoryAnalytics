using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAnalytics.Api.Data.Entities
{
    [Table("ViewSupplierCategory", Schema = "Purchasing")]
    public class ViewSupplierCategory
    {

        [Key]
            public int SupplierID { get; set; }
            public string SupplierName { get; set; }
            public int SupplierCategoryID { get; set; }
            public string SupplierCategoryName { get; set; }
    }
}
