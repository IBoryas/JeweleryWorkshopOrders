﻿using JewelryWorkshopOrders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Dal.Interfaces
{
    public interface IMaterialTypeRepository
    {
        Task<List<MaterialType>> GetAll();
    }
}
