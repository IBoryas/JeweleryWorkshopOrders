using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Domain
{
    public class Client:Person
    {
        public string PhoneNumber { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
