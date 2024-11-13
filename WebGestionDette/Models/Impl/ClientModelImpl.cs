using Microsoft.EntityFrameworkCore;
using WebGestionDette.Core;
using WebGestionDette.Entities;

namespace WebGestionDette.Models.Impl
{
    public class ClientModelImpl : IClientModel
    {
        public void Delete(int id)
        {
            using (var context = new WebGesDetteContext())
            {
                context.Remove(SelectById(id)!);
                context.SaveChanges();
            }
        }

        public int Insert(Client entity)
        {
            using (var context = new WebGesDetteContext())
            {
                context.Clients.Add(entity);
                context.SaveChanges();
                return entity.Id;
            }
        }

        public List<Client> SelectAll()
        {
            using (var context = new WebGesDetteContext())
            {
                return context.Clients.Include(c => c.User).ToList();
            }
        }

        public Client? SelectById(int id)
        {
            using (var context = new WebGesDetteContext())
            {
                return context.Clients.FirstOrDefault(c => c.Id == id);
            }
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