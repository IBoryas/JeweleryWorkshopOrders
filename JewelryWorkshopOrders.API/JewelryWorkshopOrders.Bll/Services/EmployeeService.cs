using AutoMapper;
using JewelryWorkshopOrders.Bll.Interfaces;
using JewelryWorkshopOrders.Common.Dtos.Employees;
using JewelryWorkshopOrders.Common.Dtos.Orders;
using JewelryWorkshopOrders.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Bll.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<EmployeeDto>> GetAllEmployees()
        {
            var employees = await _repository.GetAll();
            var employeesDto = _mapper.Map<List<EmployeeDto>>(employees);
            return employeesDto;
        }
    }
}
