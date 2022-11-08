using AutoMapper;
using JewelryWorkshopOrders.Bll.Interfaces;
using JewelryWorkshopOrders.Common.Dtos.Client;
using JewelryWorkshopOrders.Dal.Interfaces;
using JewelryWorkshopOrders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Bll.Services
{
    public class ClientService:IClientService
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClientDto> GetById(int id)
        {
            var client = await _repository.GetById(id);
            return _mapper.Map<ClientDto>(client);
        }

        public async Task<List<ClientsListDto>> GetAll()
        {
            var list = await _repository.GetAll();
            return _mapper.Map<List<ClientsListDto>>(list);
        }
    }
}
