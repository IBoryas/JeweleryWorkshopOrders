using JewelryWorkshopOrders.Bll.Interfaces;
using JewelryWorkshopOrders.Common.Dtos.PriceList;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.API.Controllers
{
    [Route("api/pricelist")]
    [ApiController]
    public class PriceController: ControllerBase
    {
        private readonly IPriceService _service;

        public PriceController(IPriceService service)
        {
            _service = service;
        }

        [HttpGet("{product}/{material}")]
        public async Task<IActionResult> GetPrice(int product, int material)
        {
            var price = await _service.GetPrice(product, material);
            return Ok(price);
        }

        [HttpGet]
        public async Task<IActionResult> GetPriceList()
        {
            var list = await _service.GetPriceList();
            return Ok(list);
        }

        [HttpPatch]
        public async Task<IActionResult> SetPrice([FromBody] PriceDto updatePriceDto)
        {
            await _service.Update(updatePriceDto);
            return Ok();
        }
    }
}
