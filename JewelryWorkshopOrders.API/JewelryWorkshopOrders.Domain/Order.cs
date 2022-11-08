using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Domain
{
    public class Order
    {
        public int Id { get; set; } 
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }
        public double TakenWeight { get; set; }
        public DateTime StartDate { get; } = DateTime.Now;
        public DateTime? EndDate { get; set; }
        public double Price { get; set; }
        public string Notes { get; set; }
    }
}
