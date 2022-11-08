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
    public class MaterialRepository: IMaterialRepository
    {
        private readonly DbSet<Material> _materials;

        public MaterialRepository(DbContext context)
        {
            _materials = context.Set<Material>();
        }
        public async Task<List<Material>> GetByType(int type)
        {
            return await _materials
                .Where(e=>e.MaterialTypeId == type)
                .ToListAsync();
        }
    }
}
