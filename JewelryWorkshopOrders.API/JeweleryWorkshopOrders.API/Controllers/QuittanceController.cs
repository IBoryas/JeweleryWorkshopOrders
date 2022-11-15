
using JewelryWorkshopOrders.Bll.Interfaces;
using JewelryWorkshopOrders.Common.QuittanceDate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.IO;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.API.Controllers
{
    [Route("api/print")]
    [Authorize]
    [ApiController]
    public class QuittanceController: ControllerBase
    {
        private readonly IQuittanceService _service;

        public QuittanceController(IQuittanceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderQuittance([FromQuery] OrderQuittance order)
        {
            var res = await _service.GetOrderQuittanceStream(order);
            string fileName = "Quittance.pdf";
            new FileExtensionContentTypeProvider().TryGetContentType(fileName, out string type);
            return File(res,type,fileName);
        }
    }
}
