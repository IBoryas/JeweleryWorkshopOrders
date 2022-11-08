using JewelryWorkshopOrders.Dal.Interfaces;
using JewelryWorkshopOrders.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Dal.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly DbSet<Product> _products;

        public ProductRepository(DbContext context)
        {
            _products = context.Set<Product>();
        }
        public async Task<List<Product>> GetByCategory(int type)
        {
            return await _products
                .Where(e => e.CategoryId == type)
                .ToListAsync();
        }
    }
}
