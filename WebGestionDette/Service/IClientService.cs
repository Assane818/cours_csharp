using WebGestionDette.Core;
using WebGestionDette.Models;

namespace WebGestionDette.Service
{
    public interface IClientService : IService<Client>
    {
        Client? SelectByPhone(String phone);
        Client? SelectBySurname(String surname);
        List<Client> SelectClientAccount();
        List<Client> SelectClientNoAccount();
        Client? SelectByUser(User user);
        void Delete(int id);
    }
}