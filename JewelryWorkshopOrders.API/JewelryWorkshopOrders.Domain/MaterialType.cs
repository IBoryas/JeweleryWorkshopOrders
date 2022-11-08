using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Domain
{
    public class MaterialType
    {
        public int Id { get; set; }
        public string Material { get; set; }
        public virtual List<Material> Materials { get; set; }
        public virtual List<PriceList> Prices { get; set; }
    }
}
