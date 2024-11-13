namespace WebGestionDette.Core
{
    public interface IModel<T>
    {
        int Insert(T entity);
        List<T> SelectAll();
        T? SelectById(int id);
    }
}