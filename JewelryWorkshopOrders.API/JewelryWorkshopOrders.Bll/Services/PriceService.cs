using AutoMapper;
using JewelryWorkshopOrders.Bll.Interfaces;
using JewelryWorkshopOrders.Common.Dtos.PriceList;
using JewelryWorkshopOrders.Dal.Interfaces;
using JewelryWorkshopOrders.Dal.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Bll.Services
{
    public class PriceService: IPriceService
    {
        private readonly IPriceRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PriceService(IPriceRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PriceDto> GetPrice(int product, int material)
        {
            var price = await _repository.GetPrice(product, material);
            return _mapper.Map<PriceDto>(price);
        }

        public async Task<List<PriceListDto>> GetPriceList()
        {
            var list = await _repository.GetPriceList();
            var listDto = _mapper.Map<List<PriceListDto>>(list);
            return listDto;
        }

        public async Task Update(PriceDto updatePrice)
        {
            var price = await _repository.GetPrice(updatePrice.ProductId, updatePrice.MaterialId);
            _mapper.Map(updatePrice, price);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
