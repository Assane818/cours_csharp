using GesDette.Core.Db;
using GesDette.Data.Entities;
using GesDette.Data.Enums;

namespace GesDette.Data.Repository.EntityFramework
{
    public class UserRepositoryImplEf : IUserRepository
    {
        public int Insert(User entity)
        {
            using (var context = new GesDetteContext()) {
                context.Users.Add(entity);
                context.SaveChanges();
                return entity.Id;
            }
        }

        public List<User> SelectAll()
        {
            using (var context = new GesDetteContext()) {
                return context.Users.ToList();
            }
        }

        public List<User> SelectAllUsersByEtat()
        {
            using (var context = new GesDetteContext()) {
                return context.Users.Where(u => u.Etat == true).ToList();
            }
        }

        public List<User> SelectAllUsersByRole(Role role)
        {
            using (var context = new GesDetteContext()) {
                return context.Users.Where(u => u.Role == role).ToList();
            }
        }

        public User? SelectById(int id)
        {
            using (var context = new GesDetteContext()) {
                return context.Users.FirstOrDefault(u => u.Id == id);
            }
        }

        public User? SelectByLogin(string login)
        {
            using (var context = new GesDetteContext()) {
                return context.Users.FirstOrDefault(u => u.Login == login);
            }
        }

        public User? SelectUserConnect(string login, string password)
        {
            using (var context = new GesDetteContext()) {
                return context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
            }
        }

        public bool UpdateEtat(User user, bool etat)
        {
            using (var context = new GesDetteContext()) {
                var entity = context.Users.FirstOrDefault(u => u.Id == user.Id);
                if (entity!= null) {
                    entity.Etat = etat;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}