using AutoMapper;
using JewelryWorkshopOrders.Bll.Interfaces;
using JewelryWorkshopOrders.Common.Dtos.Client;
using JewelryWorkshopOrders.Common.Dtos.Orders;
using JewelryWorkshopOrders.Dal.Interfaces;
using JewelryWorkshopOrders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace JewelryWorkshopOrders.Bll.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository repository,
            IMapper mapper, 
            IClientRepository clientRepository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(CreateOrderWithClientDto orderCreateDto)
        {
            using TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled);
            var client = _mapper.Map<Client>(orderCreateDto);
            var clientId = await _clientRepository.FindOrCreate(client);
            var order = _mapper.Map<Order>(orderCreateDto);
            await _repository.Add(order,clientId);
            await _unitOfWork.SaveChangesAsync();
            transaction.Complete();
        }

        public async Task<OrderDto> GetById(int id)
        {
            var order = await _repository.GetByIdWithTypes(id);
            var orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;
        }

        public async Task<List<OrderListDto>> GetAllOrders()
        {
            var orders = await _repository.GetAllOrders();
            var ordersDto = _mapper.Map<List<OrderListDto>>(orders);
            return ordersDto;
        }

        public async Task<List<CompletedOrderListDto>> GetCompleted()
        {
            var orders = await _repository.GetCompleted();
            var ordersDto = _mapper.Map<List<CompletedOrderListDto>>(orders);
            return ordersDto;
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Update(int id, CreateOrderWithClientDto orderCreateDto)
        {
            using TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled);
            var order = await _repository.GetById(id);
            _mapper.Map(orderCreateDto, order);
            var client = _mapper.Map<Client>(orderCreateDto);
            var clientId = await _clientRepository.FindOrCreate(client);
            order.ClientId = clientId;
            await _unitOfWork.SaveChangesAsync();
            transaction.Complete();
        }

        public async Task Complete(int id)
        {
            await _repository.Complete(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
