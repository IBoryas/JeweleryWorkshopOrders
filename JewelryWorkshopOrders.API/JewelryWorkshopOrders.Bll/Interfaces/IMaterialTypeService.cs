using JewelryWorkshopOrders.Common.Dtos.Employees;
using JewelryWorkshopOrders.Common.Dtos.MaterialType;
using JewelryWorkshopOrders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Bll.Interfaces
{
    public interface IMaterialTypeService
    {
        Task<List<MaterialTypeDto>> GetAllMaterialTypes();
    }
}
