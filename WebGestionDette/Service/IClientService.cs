using WebGestionDette.Core;
using WebGestionDette.Models;

namespace WebGestionDette.Service
{
    public interface IClientService : IService<Client>
    {
        Client? SelectByUser(User user);
        Task Delete(int id);
        Task<IEnumerable<Client>> SelectClientsAsync();
        Task<IEnumerable<Client>> SelectClientsAsync(int pageNumber, int limit);
        Task<Client?> SelectBySurname(string surname);

    }
}