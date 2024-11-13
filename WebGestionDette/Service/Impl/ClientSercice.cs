using Microsoft.EntityFrameworkCore;
using WebGestionDette.Data;
using WebGestionDette.Service;

namespace WebGestionDette.Models.Impl
{
    public class ClientService : IClientService
    {
        public readonly WebGesDetteContext _context;
        public ClientService(WebGesDetteContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {  
            _context.Remove(SelectById(id)!);
            _context.SaveChanges();
        }

        public async Task<int> Insert(Client entity)
        {
            await _context.Clients.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Client>> SelectClientsAsync()
        {
            return await _context.Clients.Include(c => c.User).ToListAsync();
        }

        public Client? SelectById(int id)
        {
            return _context.Clients.FirstOrDefault(c => c.Id == id);
        }

        public Client? SelectByPhone(string phone)
        {
            throw new NotImplementedException();
        }

        public Client? SelectBySurname(string surname)
        {
            throw new NotImplementedException();
        }

        public Client? SelectByUser(User user)
        {
            throw new NotImplementedException();
        }

        public List<Client> SelectClientAccount()
        {
            throw new NotImplementedException();
        }

        public List<Client> SelectClientNoAccount()
        {
            throw new NotImplementedException();
        }
    }
}