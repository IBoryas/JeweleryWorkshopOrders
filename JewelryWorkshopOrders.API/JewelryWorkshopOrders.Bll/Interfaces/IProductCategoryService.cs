using JewelryWorkshopOrders.Common.Dtos.MaterialType;
using JewelryWorkshopOrders.Common.Dtos.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Bll.Interfaces
{
    public interface IProductCategoryService
    {
        Task<List<ProductCategoryDto>> GetAllProductCategories();
    }
}
