using JewelryWorkshopOrders.Bll.Interfaces;
using JewelryWorkshopOrders.Common.Dtos.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.API.Controllers
{
    [Route("api/clients")]
    [Authorize]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = await _service.GetById(id);
            return Ok(client);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _service.GetAll();
            return Ok(clients);
        }
    }
}
