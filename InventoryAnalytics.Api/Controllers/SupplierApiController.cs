using InventoryAnalytics.Api.Data.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAnalytics.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierApiController : ControllerBase
    {
        private readonly ISupplierRepository supplierRepository;

        public SupplierApiController(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }
        [HttpGet("GetAllSuppliers")]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var suppliers = await this.supplierRepository.GetAllSuppliersAsync();
            return Ok(suppliers);
        }
        [HttpGet("GetAllSuppliersCategories")]
        public async Task<IActionResult> GetAllSuppliersCategories()
        {
            var suppliers = await this.supplierRepository.GetAllSuppliersCategoriesAsync();
            return Ok(suppliers);
        }
    }
}
