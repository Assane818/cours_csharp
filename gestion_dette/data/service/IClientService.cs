using GesDette.Data.Entities;

namespace GesDette.Data.Service
{
    public interface IClientService : IService<Client>
    {
        Client GetByPhone(String phone);
        Client GetBySurname(String surname);
        List<Client> GetClientAccount();
        List<Client> GetClientNoAccount();
        Client GetByUser(User user);
    }
}