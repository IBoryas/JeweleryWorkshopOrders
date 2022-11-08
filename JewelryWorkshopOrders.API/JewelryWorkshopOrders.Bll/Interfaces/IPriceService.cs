using JewelryWorkshopOrders.Common.Dtos.PriceList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Bll.Interfaces
{
    public interface IPriceService
    {
        Task<PriceDto> GetPrice(int product, int material);
        Task<List<PriceListDto>> GetPriceList();
        Task Update(PriceDto updatePriceDto); 
    }
}
