using GesDette.Core.Repository;

namespace GesDette.Core.Factory
{
    public interface IRepositoryFactory<T>
    {
        IRepository<T> GetRepository();
    }
}