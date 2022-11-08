using AutoMapper;
using JewelryWorkshopOrders.Common.Dtos.Material;
using JewelryWorkshopOrders.Common.Dtos.Product;
using JewelryWorkshopOrders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Bll.Profiles
{
    internal class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
