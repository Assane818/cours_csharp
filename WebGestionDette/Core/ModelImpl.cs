
using WebGestionDette.Entities;

namespace WebGestionDette.Core
{
    public class ModelImpl<T> : IModel<T> where T : AbstractEntity
    {
        public int Insert(T entity)
        {
            using (var context = new WebGesDetteContext())
            {
                var con = context.Set<T>();
                con.Add(entity);
                return context.SaveChanges();
            }
        }

        public List<T> SelectAll()
        {
            using (var context = new WebGesDetteContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public T? SelectById(int id)
        {
            using (var context = new WebGesDetteContext())
            {
                return context.Set<T>().Find(id);
            }
        }
    }
}