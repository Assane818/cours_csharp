using WebGestionDette.Core;
using WebGestionDette.Entities;

namespace WebGestionDette.Models
{
    public interface IClientModel : IModel<Client>
    {
        Client? SelectByPhone(String phone);
        Client? SelectBySurname(String surname);
        List<Client> SelectClientAccount();
        List<Client> SelectClientNoAccount();
        Client? SelectByUser(User user);
        void Delete(int id);
    }
}