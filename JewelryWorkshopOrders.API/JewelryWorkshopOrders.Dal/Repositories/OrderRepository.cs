using JewelryWorkshopOrders.Dal.Interfaces;
using JewelryWorkshopOrders.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Dal.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbSet<Order> _orders;

        public OrderRepository(DbContext context)
        {
            _orders = context.Set<Order>();
        }

        public async Task Add(Order order, int clientId)
        {
            order.ClientId = clientId;
            await _orders.AddAsync(order);
        }

        public async Task<List<Order>> GetOrders(Expression<Func<Order,bool>> predicate)
        {
            return await _orders
                .Where(predicate)
                .Include(o => o.Material.MaterialType)
                .Include(o => o.Product.Category)
                .Include(o => o.Client)
                .Include(o => o.Employee)
                .ToListAsync();
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await GetOrders(o => o.EndDate == null);
        }

        public async Task<List<Order>> GetCompleted()
        {
            return await GetOrders(o => o.EndDate != null);
        }

        public async Task Delete(int id)
        {
            var order = await _orders.FindAsync(id);
            _orders.Remove(order);
        }

        public async Task<Order> GetById(int id)
        {
            return await _orders.FindAsync(id);
        }

        public async Task<Order> GetByIdWithTypes(int id)
        {
            return await _orders
                .Include(o => o.Material)
                .Include(o => o.Product)
                .Include(o=>o.Client)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task Complete(int id)
        {
            var order = await _orders.FindAsync(id);
            order.EndDate = DateTime.Now;
        }
    }
}
