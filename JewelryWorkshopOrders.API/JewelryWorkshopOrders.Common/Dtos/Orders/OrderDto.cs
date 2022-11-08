using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Common.Dtos.Orders
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string ClientFullName { get; set; }
        public int EmployeeId { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductId { get; set; }
        public int MaterialTypeId { get; set; }
        public int MaterialId { get; set; }
        public double TakenWeight { get; set; }
        public double Price { get; set; }
        public string Notes { get; set; }
    }
}
