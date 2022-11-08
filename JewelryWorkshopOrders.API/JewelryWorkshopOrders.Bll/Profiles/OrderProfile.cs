using AutoMapper;
using JewelryWorkshopOrders.Common.Dtos.Client;
using JewelryWorkshopOrders.Common.Dtos.Orders;
using JewelryWorkshopOrders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Bll.Mappers
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderListDto>()
                .ForMember(
                    x => x.Client,
                    y => y.MapFrom(z => z.Client.FullName()))
                .ForMember(
                    x => x.Employee,
                    y => y.MapFrom(z => z.Employee.FullName()))
                .ForMember(
                    x => x.Product,
                    y => y.MapFrom(z => z.Product.GetInfo()))
                .ForMember(
                    x => x.Material,
                    y => y.MapFrom(z => z.Material.GetInfo()));

            CreateMap<Order, CompletedOrderListDto>()
                .ForMember(
                    x => x.Client,
                    y => y.MapFrom(z => z.Client.FullName()))
                .ForMember(
                    x => x.Employee,
                    y => y.MapFrom(z => z.Employee.FullName()))
                .ForMember(
                    x => x.Product,
                    y => y.MapFrom(z => z.Product.GetInfo()))
                .ForMember(
                    x => x.Material,
                    y => y.MapFrom(z => z.Material.GetInfo()));

            CreateMap<CreateOrderWithClientDto, Order>();

            CreateMap<CreateOrderWithClientDto, Client>();

            CreateMap<Order, OrderDto>()
                .ForMember(
                    x=>x.ProductTypeId,
                    y=>y.MapFrom(z=>z.Product.CategoryId))
                .ForMember(
                    x=>x.MaterialTypeId,
                    y=>y.MapFrom(z=>z.Material.MaterialTypeId))
                .ForMember(
                    x=>x.ClientFullName,
                    y=>y.MapFrom(z=> $"{z.Client.FullName()} ({z.Client.PhoneNumber})"));

            CreateMap<Client, OrderDto>();
        }
    }
}
