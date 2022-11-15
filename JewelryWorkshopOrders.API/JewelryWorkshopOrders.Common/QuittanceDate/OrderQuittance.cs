using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Common.QuittanceDate
{
    public class OrderQuittance
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string MaterialType { get; set; }
        public int MaterialContent { get; set; }
        public double Weight { get; set; }
        public string Master { get; set; }
        public string ProductType { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
        public string Date { get; } = DateTime.Now.ToString("d");
    }
}
