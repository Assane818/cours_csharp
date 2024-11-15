using WebGestionDette.Core;
using WebGestionDette.Models;
using WebGestionDette.Models.Enum;

namespace WebGestionDette.Service.Impl
{
    public class UserService : IUserService
    {
        public Task<int> Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> SelectClientsAsync(int pageNumber, int limit)
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

        public Task<IEnumerable<Client>> SelectClientsAsync()
        {
            throw new NotImplementedException();
        }




        public Task<User?> SelectById(int id)
        {
            throw new NotImplementedException();
        }
    }
}