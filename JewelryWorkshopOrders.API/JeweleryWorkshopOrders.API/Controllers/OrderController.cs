using JewelryWorkshopOrders.Bll.Interfaces;
using JewelryWorkshopOrders.Common.Dtos.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JewelryWorkshopOrders.API.Controllers
{
    [Route("api/orders")]
    [Authorize]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orderList = await _service.GetAllOrders();
            return Ok(orderList);
        }

        [HttpGet("completed")]
        public async Task<IActionResult> GetCompleted()
        {
            var orderList = await _service.GetCompleted();
            return Ok(orderList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _service.GetById(id);
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderWithClientDto orderCreateDto)
        {
            await _service.Add(orderCreateDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateOrderWithClientDto orderCreateDto)
        {
            await _service.Update(id, orderCreateDto);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Complete(int id)
        {
            await _service.Complete(id);
            return Ok();
        }
    }
}
