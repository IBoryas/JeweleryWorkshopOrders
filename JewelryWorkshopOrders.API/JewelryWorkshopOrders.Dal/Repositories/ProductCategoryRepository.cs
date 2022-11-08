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
    public class ProductCategoryRepository: IProductCategoryRepository
    {
        private readonly DbSet<ProductCategory> _categories;

        public ProductCategoryRepository(DbContext context)
        {
            _categories = context.Set<ProductCategory>();
        }
        public async Task<List<ProductCategory>> GetAll()
        {
            return await _categories.ToListAsync();
        }
    }
}
