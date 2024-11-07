using GesDette.Core.Repository;
using GesDette.Data.Entities;
namespace GesDette.Data.Repository
{
    public interface IClientRepository : IRepository<Client> {
        Client SelectByPhone(String phone);
        Client SelectById(int id);
        Client SelectBySurname(String surname);
        List<Client> SelectClientAccount();
        List<Client> SelectClientNoAccount();
        Client SelectByUser(User user);
    }   
}