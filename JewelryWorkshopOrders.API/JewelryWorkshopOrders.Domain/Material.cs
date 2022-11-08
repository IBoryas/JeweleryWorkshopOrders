using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Domain
{
    public class Material
    {
        public int Id { get; set; }
        public int MaterialTypeId { get; set; }
        public virtual MaterialType MaterialType { get; set; }
        public int Content { get; set; }
        public virtual List<Order> Orders { get; set; }

        public string GetInfo() => $"{MaterialType.Material} {Content}";
    }
}
