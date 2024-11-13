using WebGestionDette.Models;

namespace WebGestionDette.Core
{
    public interface IService<T>
    {
        Task<int> Insert(T entity);
        Task<IEnumerable<Client>> SelectClientsAsync();
        T? SelectById(int id);
    }
}