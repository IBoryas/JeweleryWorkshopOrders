using JewelryWorkshopOrders.Bll.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController:ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("{type}")]
        public async Task<IActionResult> GetAll(int type)
        {
            var list = await _service.GetByCategory(type);
            return Ok(list);
        }
    }
}
