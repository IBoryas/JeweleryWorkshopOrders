using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelryWorkshopOrders.Common.Dtos.Orders;

namespace JewelryWorkshopOrders.Bll.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderListDto>> GetAllOrders();
        Task Add(CreateOrderWithClientDto orderCreateDto);
        Task<List<CompletedOrderListDto>> GetCompleted();
        Task Delete(int id);
        Task Update(int id, CreateOrderWithClientDto orderCreateDto);
        Task Complete(int id);
        Task<OrderDto> GetById(int id);
    }
}
