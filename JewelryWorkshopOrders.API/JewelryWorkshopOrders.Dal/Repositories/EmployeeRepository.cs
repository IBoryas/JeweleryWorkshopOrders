using JewelryWorkshopOrders.Dal.Interfaces;
using JewelryWorkshopOrders.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Dal.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DbSet<Employee> _employees;

        public EmployeeRepository(DbContext context)
        {
            _employees = context.Set<Employee>();
        }
        public async Task<List<Employee>> GetAll()
        {
            return await _employees.ToListAsync();
        }
    }
}
