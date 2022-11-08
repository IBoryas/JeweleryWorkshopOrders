using AutoMapper;
using JewelryWorkshopOrders.Common.Dtos.MaterialType;
using JewelryWorkshopOrders.Common.Dtos.ProductCategory;
using JewelryWorkshopOrders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Bll.Profiles
{
    internal class ProductCategoryProfile : Profile
    {
        public ProductCategoryProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDto>();
        }
    }
}
