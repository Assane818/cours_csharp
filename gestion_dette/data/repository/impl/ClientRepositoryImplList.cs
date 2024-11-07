using GesDette.Core.Repository.Impl;
using GesDette.Data.Entities;

namespace GesDette.Data.Repository.Impl
{
    public class ClientRepositoryImplList : RepositoryImplList<Client>, IClientRepository
    {
        public ClientRepositoryImplList() {
            Client client = new () {
                Surname = "vini07",
                Phone = "771001010",
                Address = "RIO",
                User = null
            };
            list.Add(client);
        }
        public Client SelectById(int id)
        {
            return list.Find(client => client.Id == id);
        }

        public Client SelectByPhone(string phone)
        {
            return list.Find(client => client.Phone.CompareTo(phone) == 0);
        }

        public Client SelectBySurname(string surname)
        {
            return list.Find(client => client.Surname.CompareTo(surname) == 0);
        }

        public Client SelectByUser(User user)
        {
            return list.Find(client => client.User != null && client.User.Id == user.Id);
        }

        public List<Client> SelectClientAccount()
        {
            return list.Where(client => client.User != null).ToList();
        }

        public List<Client> SelectClientNoAccount()
        {
            return list.Where(client => client.User == null).ToList();
        }
    }
}