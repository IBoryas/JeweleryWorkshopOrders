using AutoMapper;
using JewelryWorkshopOrders.Bll.Interfaces;
using JewelryWorkshopOrders.Common.Dtos.MaterialType;
using JewelryWorkshopOrders.Common.Dtos.ProductCategory;
using JewelryWorkshopOrders.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Bll.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _repository;
        private readonly IMapper _mapper;

        public ProductCategoryService(IProductCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductCategoryDto>> GetAllProductCategories()
        {
            var list = await _repository.GetAll();
            var listDto = _mapper.Map<List<ProductCategoryDto>>(list);
            return listDto;
        }
    }
}
