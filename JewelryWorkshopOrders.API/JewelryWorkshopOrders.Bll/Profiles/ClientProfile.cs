using AutoMapper;
using JewelryWorkshopOrders.Common.Dtos.Client;
using JewelryWorkshopOrders.Common.Dtos.Employees;
using JewelryWorkshopOrders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Bll.Profiles
{
    internal class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<CreateClientDto, Client>();
            
            CreateMap<Client,ClientDto>();

            CreateMap<Client, ClientsListDto>()
                .ForMember(
                    x => x.ClientData,
                    y => y.MapFrom(z => $"{z.FullName()} ({z.PhoneNumber})"));
        }
    }
}
