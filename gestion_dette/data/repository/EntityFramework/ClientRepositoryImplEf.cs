using GesDette.Core.Db;
using GesDette.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GesDette.Data.Repository.EntityFramework
{
    public class ClientRepositoryImplEf : IClientRepository
    {
        public int Insert(Client entity)
        {
            using (var context = new GesDetteContext())
            {
                context.Clients.Add(entity);
                context.SaveChanges();
                return entity.Id;
            }
        }

        public List<Client> SelectAll()
        {
            using (var context = new GesDetteContext())
            {
                return context.Clients.Include(c => c.User).ToList();
            }
        }

        public Client? SelectById(int id)
        {
            using (var context = new GesDetteContext())
            {
                return context.Clients.Include(c => c.User).FirstOrDefault(c => c.Id == id);
            }
        }

        public Client? SelectByPhone(string phone)
        {
            using (var context = new GesDetteContext())
            {
                return context.Clients.FirstOrDefault(c => c.Phone == phone);
            }
        }

        public Client? SelectBySurname(string surname)
        {
            using (var context = new GesDetteContext())
            {
                return context.Clients.FirstOrDefault(c => c.Surname == surname);
            }
        }

        public Client? SelectByUser(User user)
        {
            using (var context = new GesDetteContext())
            {
                return context.Clients.FirstOrDefault(c => c.User!= null && c.User.Id == user.Id);
            }
        }

        public List<Client> SelectClientAccount()
        {
            using (var context = new GesDetteContext())
            {
                return context.Clients.Where(c => c.User != null).ToList();
            }
        }

        public List<Client> SelectClientNoAccount()
        {
            using (var context = new GesDetteContext())
            {
                return context.Clients.Where(c => c.User == null).ToList();
            }
        }
    }
}