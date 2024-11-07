using GesDette.Data.Entities;
using GesDette.Data.Enums;

namespace GesDette.Data.Service
{
    public interface IUserService : IService<User>
    {

        List<User> GetUsersByEtat();
        List<User> GetUsersByRole(Role role);
        User GetByLogin(String login);
        User SelectUserConnect(String login, String password);
        bool UpdateEtat(User user, bool etat);
    }
}