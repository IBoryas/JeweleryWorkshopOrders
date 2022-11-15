using JewelryWorkshopOrders.Bll.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.API.Controllers
{
    [Route("api/employees")]
    [Authorize]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employeeList = await _service.GetAllEmployees();
            return Ok(employeeList);
        }
    }
}
