using JewelryWorkshopOrders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Dal.Seed
{
    public class EmployeeSeed
    {
        public static async Task Seed(JewelryWorkshopOrdersDbContext context)
        {
            if (!context.Employees.Any())
            {
                var borysenko = new Employee()
                {
                    LastName = "Borysenko",
                    FirstName = "Ilia",
                    Patronymic = "Eugheniu"
                };

                var zaleatdinov = new Employee()
                {
                    LastName = "Zaleatdinov",
                    FirstName = "Artur",
                    Patronymic = "Serghei"
                };

                var proscurchin = new Employee()
                {
                    LastName = "Proscurchin",
                    FirstName = "Artiom",
                    Patronymic = "Victor"
                };

                context.Employees.AddRange(borysenko, zaleatdinov, proscurchin);

                await context.SaveChangesAsync();
            }
        }
    }
}
