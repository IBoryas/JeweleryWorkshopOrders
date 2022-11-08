using AutoMapper;
using JewelryWorkshopOrders.Common.Dtos.Employees;
using JewelryWorkshopOrders.Common.Dtos.Orders;
using JewelryWorkshopOrders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Bll.Profiles
{
    public class EmployeeProfile: Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(
                    x => x.Name,
                    y => y.MapFrom(z => z.FullName()));
        }
    }
}
