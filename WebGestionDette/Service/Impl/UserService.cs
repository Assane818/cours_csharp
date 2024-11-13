using GesDette.Models;
using WebGestionDette.Core;
using WebGestionDette.Models.Enum;

namespace WebGestionDette.Models.Impl
{
    public class UserService : IUserService
    {
        public int Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> SelectClientsAsync()
        {
            throw new NotImplementedException();
        }

        public List<User> SelectAllUsersByEtat()
        {
            throw new NotImplementedException();
        }

        public List<User> SelectAllUsersByRole(Role role)
        {
            throw new NotImplementedException();
        }

        public User? SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public User? SelectByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public User? SelectUserConnect(string login, string password)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEtat(User user, bool etat)
        {
            throw new NotImplementedException();
        }

        Task<int> IService<User>.Insert(User entity)
        {
            throw new NotImplementedException();
        }
    }
}