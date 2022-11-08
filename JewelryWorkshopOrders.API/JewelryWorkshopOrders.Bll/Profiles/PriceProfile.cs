using AutoMapper;
using JewelryWorkshopOrders.Common.Dtos.PriceList;
using JewelryWorkshopOrders.Common.Dtos.ProductCategory;
using JewelryWorkshopOrders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Bll.Profiles
{
    internal class PriceProfile : Profile
    {
        public PriceProfile()
        {
            CreateMap<PriceList, PriceListDto>()
                .ForMember(
                    x => x.Material,
                    y => y.MapFrom(z => z.Material.Material))
                .ForMember(
                    x => x.ProductCategory,
                    y => y.MapFrom(z => z.Product.Category.CategoryName))
                .ForMember(
                    x => x.Product,
                    y => y.MapFrom(z => z.Product.ProductName));

            CreateMap<PriceDto, PriceList>();
            CreateMap<PriceList, PriceDto>();
        }
    }
}
