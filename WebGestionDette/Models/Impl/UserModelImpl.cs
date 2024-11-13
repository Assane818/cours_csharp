using GesDette.Models;
using WebGestionDette.Core;
using WebGestionDette.Entities;
using WebGestionDette.Enums;

namespace WebGestionDette.Models.Impl
{
    public class UserModelImpl : ModelImpl<User>, IUserModel
    {
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
    }
}