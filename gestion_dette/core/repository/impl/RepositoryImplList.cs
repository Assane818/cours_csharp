
using GesDette.Data.entities;

namespace GesDette.Core.Repository.Impl
{
    public class RepositoryImplList<T> : IRepository<T> where T : AbstractEntity
    {
        protected readonly List<T> list = new List<T>();
        public int Insert(T entity)
        {
            list.Add(entity);
            return entity.Id;
        }

        public List<T> SelectAll()
        {
            return list;
        }
    }
}