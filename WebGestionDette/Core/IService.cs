using WebGestionDette.Models;

namespace WebGestionDette.Core
{
    public interface IService<T>
    {
        Task<int> Insert(T entity);
        Task<T?> SelectById(int id);
    }
}