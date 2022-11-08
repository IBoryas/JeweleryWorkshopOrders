using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Common.Dtos.Orders
{
    public class CompletedOrderListDto
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public string Employee { get; set; }
        public string Product { get; set; }
        public string Material { get; set; }
        public double TakenWeight { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
        public string Notes { get; set; }
    }
}
