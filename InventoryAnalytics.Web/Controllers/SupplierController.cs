using InventoryAnalytics.Application.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAnalytics.Web.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierApiRepository _supplierApi;

        public SupplierController(ISupplierApiRepository supplierApi)
        {
            _supplierApi = supplierApi;
        }
        public async Task<IActionResult>  Index()
        {
            var suppliers = await _supplierApi.GetSuppliersAsync();    
            return View(suppliers);
        }
    }
}
