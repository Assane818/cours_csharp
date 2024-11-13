using WebGestionDette.Core;
using WebGestionDette.Entities;
using WebGestionDette.Enums;

namespace GesDette.Models
{
    public interface IUserModel : IModel<User>
    {
        User? SelectByLogin(String login);
        bool UpdateEtat(User user, bool etat);
        List<User> SelectAllUsersByEtat();
        List<User> SelectAllUsersByRole(Role role);
        User? SelectUserConnect(String login, String password);
    }
}