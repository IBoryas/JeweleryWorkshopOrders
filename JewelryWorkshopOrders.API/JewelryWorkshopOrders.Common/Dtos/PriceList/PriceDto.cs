using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Common.Dtos.PriceList
{
    public class PriceDto
    {
        public int MaterialId { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
    }
}
