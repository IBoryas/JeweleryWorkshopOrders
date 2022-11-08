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
    public class PriceRepository: IPriceRepository
    {
        private readonly DbSet<PriceList> _prices;

        public PriceRepository(DbContext context)
        {
            _prices = context.Set<PriceList>();
        }

        public async Task SetPrice(int product, int material, int newPrice)
        {
            var price = await _prices.FindAsync(product, material);
            price.Price = newPrice;
        }

        public async Task<List<PriceList>> GetPriceList()
        {
            return await _prices
                .Include(x => x.Material)
                .Include(x => x.Product)
                .Include(x => x.Product.Category)
                .ToListAsync();
        }

        public async Task<PriceList> GetPrice(int product, int material)
        {
            var price = await _prices.FindAsync(product, material);
            return price;
        }
    }
}
