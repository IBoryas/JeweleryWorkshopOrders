using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Domain
{
    public class PriceList
    {
        public int MaterialId { get; set; }
        public virtual MaterialType Material { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public double Price { get; set; }
    }
}
