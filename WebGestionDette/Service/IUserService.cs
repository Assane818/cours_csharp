using WebGestionDette.Core;
using WebGestionDette.Models;
using WebGestionDette.Models.Enum;

namespace WebGestionDette.Service
{
    public interface IUserService : IService<User>
    {
        User? SelectByLogin(String login);
        bool UpdateEtat(User user, bool etat);
        List<User> SelectAllUsersByEtat();
        List<User> SelectAllUsersByRole(Role role);
        User? SelectUserConnect(String login, String password);
    }
}