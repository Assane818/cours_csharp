using Microsoft.EntityFrameworkCore;
using WebGestionDette.Core;
using WebGestionDette.Data;
using WebGestionDette.Models;

namespace WebGestionDette.Service.Impl
{
    public class ClientService : IClientService
    {
        public readonly WebGesDetteContext _context;
        public ClientService(WebGesDetteContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {  
            _context.Remove(await SelectById(id));
            await _context.SaveChangesAsync();
        }

        public async Task<int> Insert(Client entity)
        {
            _context.Clients.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Client>> SelectClientsAsync(int pageNumber, int limit)
        {
            return await _context.Clients
                .Include(c => c.User)
                .Skip((pageNumber - 1) * limit)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<Client?> SelectById(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Client? SelectByUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Client>> SelectClientsAsync()
        {
            return await _context.Clients.Include(c => c.User).ToListAsync();
        }

        public async Task<Client?> SelectBySurname(string surname)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.Surname == surname);
        }
    }
}