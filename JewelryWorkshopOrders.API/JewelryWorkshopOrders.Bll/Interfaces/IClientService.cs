using JewelryWorkshopOrders.Common.Dtos.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryWorkshopOrders.Bll.Interfaces
{
    public interface IClientService
    {
        Task<ClientDto> GetById(int id);
        Task<List<ClientsListDto>> GetAll();
    }
}
