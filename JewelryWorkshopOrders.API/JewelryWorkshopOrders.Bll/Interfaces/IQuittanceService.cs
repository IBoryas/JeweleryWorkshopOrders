using JewelryWorkshopOrders.Common.QuittanceDate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Bll.Interfaces
{
    public interface IQuittanceService
    {
        Task<Stream> GetOrderQuittanceStream(OrderQuittance order);
    }
}
