using GesDette.Data.Entities;
using GesDette.Data.Repository;

namespace GesDette.Data.Service.Impl
{
    public class ClientServiceImpl : IClientService
    {
        private IClientRepository clientRepository;
        public ClientServiceImpl(IClientRepository clientRepository) {
            this.clientRepository = clientRepository;
        }
        public Client GetById(int id)
        {
            return clientRepository.SelectById(id);
        }

        public Client GetByPhone(string phone)
        {
            return clientRepository.SelectByPhone(phone);
        }

        public Client GetBySurname(string surname)
        {
            return clientRepository.SelectBySurname(surname);
        }

        public Client GetByUser(User user)
        {
            return clientRepository.SelectByUser(user);
        }

        public List<Client> GetClientAccount()
        {
            return clientRepository.SelectClientAccount();
        }

        public List<Client> GetClientNoAccount()
        {
            return clientRepository.SelectClientNoAccount();
        }

        public int Save(Client entity)
        {
            return clientRepository.Insert(entity);
        }

        public List<Client> Show()
        {
            return clientRepository.SelectAll();
        }
    }
}