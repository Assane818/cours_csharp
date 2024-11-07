namespace GesDette.Data.Service
{
    public interface IService<T> {
        int Save(T entity);
        List<T> Show();
        T GetById(int id);
    }
}