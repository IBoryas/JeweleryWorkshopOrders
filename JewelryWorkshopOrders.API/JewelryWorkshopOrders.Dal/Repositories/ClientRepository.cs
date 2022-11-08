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
    public class ClientRepository : IClientRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Client> _clients;

        public ClientRepository(DbContext context)
        {
            _context = context;
            _clients = _context.Set<Client>();
        }

        public async Task<int> FindOrCreate(Client client)
        {
            var findClient = await _clients.FirstOrDefaultAsync(x =>
                x.FirstName == client.FirstName &&
                x.LastName == client.LastName &&
                x.Patronymic == client.Patronymic &&
                x.PhoneNumber == client.PhoneNumber);
            if (findClient is null)
            {
                await _clients.AddAsync(client);
                await _context.SaveChangesAsync();
                return client.Id;
            }
            else
                return findClient.Id;
        }

        public async Task<Client> GetById(int id)
        {
            return await _clients.FindAsync(id);
        }

        public async Task<List<Client>> GetAll()
        {
            return await _clients.ToListAsync();
        }
    }
}
