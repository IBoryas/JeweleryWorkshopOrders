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
    public class MaterialTypeRepository: IMaterialTypeRepository
    {
        private readonly DbSet<MaterialType> _materialTypes;

        public MaterialTypeRepository(DbContext context)
        {
            _materialTypes = context.Set<MaterialType>();
        }
        public async Task<List<MaterialType>> GetAll()
        {
            return await _materialTypes.ToListAsync();
        }
    }
}
