using JewelryWorkshopOrders.Common.Dtos.Material;
using JewelryWorkshopOrders.Common.Dtos.MaterialType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Bll.Interfaces
{
    public interface IMaterialService
    {
        Task<List<MaterialDto>> GetByType(int type);
    }
}
