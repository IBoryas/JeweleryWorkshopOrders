using JewelryWorkshopOrders.Common.Dtos.Material;
using JewelryWorkshopOrders.Common.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Bll.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetByCategory(int type);
    }
}
