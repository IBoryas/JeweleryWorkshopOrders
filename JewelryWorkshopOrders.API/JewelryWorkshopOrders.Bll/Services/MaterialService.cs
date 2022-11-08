using AutoMapper;
using JewelryWorkshopOrders.Bll.Interfaces;
using JewelryWorkshopOrders.Common.Dtos.Material;
using JewelryWorkshopOrders.Common.Dtos.MaterialType;
using JewelryWorkshopOrders.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Bll.Services
{
    public class MaterialService: IMaterialService
    {
        private readonly IMaterialRepository _repository;
        private readonly IMapper _mapper;

        public MaterialService(IMaterialRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<MaterialDto>> GetByType(int type)
        {
            var list = await _repository.GetByType(type);
            var listDto = _mapper.Map<List<MaterialDto>>(list);
            return listDto;
        }
    }
}
