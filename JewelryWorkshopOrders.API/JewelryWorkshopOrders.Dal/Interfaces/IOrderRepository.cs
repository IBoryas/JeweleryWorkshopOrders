using JewelryWorkshopOrders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Dal.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrders();
        Task Add(Order order, int clientId);
        Task<List<Order>> GetCompleted();
        Task Delete(int id);
        Task<Order> GetById(int id);
        Task<Order> GetByIdWithTypes(int id);
        Task Complete(int id);
    }
}
