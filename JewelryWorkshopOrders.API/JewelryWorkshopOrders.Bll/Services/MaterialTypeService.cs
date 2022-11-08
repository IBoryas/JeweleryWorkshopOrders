using AutoMapper;
using JewelryWorkshopOrders.Bll.Interfaces;
using JewelryWorkshopOrders.Common.Dtos.Employees;
using JewelryWorkshopOrders.Common.Dtos.MaterialType;
using JewelryWorkshopOrders.Dal.Interfaces;
using JewelryWorkshopOrders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Bll.Services
{
    public class MaterialTypeService:IMaterialTypeService
    {
        private readonly IMaterialTypeRepository _repository;
        private readonly IMapper _mapper;

        public MaterialTypeService(IMaterialTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<MaterialTypeDto>> GetAllMaterialTypes()
        {
            var materialTypes = await _repository.GetAll();
            var materialTypesDto = _mapper.Map<List<MaterialTypeDto>>(materialTypes);
            return materialTypesDto;
        }
    }
}
