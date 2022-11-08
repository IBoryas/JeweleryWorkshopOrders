using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public virtual ProductCategory Category { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<PriceList> Prices { get; set; }

        public string GetInfo()
        {
            return $"{Category.CategoryName} {ProductName}";
        }
    }
}
