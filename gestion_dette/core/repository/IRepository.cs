namespace GesDette.Core.Repository
{
    public interface IRepository<T> {
        int Insert(T entity);
        List<T> SelectAll(); 
    }
}