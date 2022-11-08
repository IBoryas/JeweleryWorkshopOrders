using System.Collections.Generic;

namespace JewelryWorkshopOrders.Domain
{
    public class Employee:Person
    {
        public virtual List<Order> Orders { get; set; }
    }
}