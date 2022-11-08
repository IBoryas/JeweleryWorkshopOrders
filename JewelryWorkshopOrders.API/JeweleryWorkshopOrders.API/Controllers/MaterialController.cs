using JewelryWorkshopOrders.Bll.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.API.Controllers
{
    [Route("api/materials")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _service;

        public MaterialController(IMaterialService service)
        {
            _service = service;
        }

        [HttpGet("{type}")]
        public async Task<IActionResult> GetAll(int type)
        {
            var list = await _service.GetByType(type);
            return Ok(list);
        }
    }
}
