using GesDette.Core.Repository;
using GesDette.Data.Entities;
using GesDette.Data.Enums;

namespace GesDette.Data.Repository
{
    public interface IUserRepository : IRepository<User> {
        User? SelectByLogin(String login);
        User? SelectById(int id);
        bool UpdateEtat(User user, bool etat);
        List<User> SelectAllUsersByEtat();
        List<User> SelectAllUsersByRole(Role role);
        User? SelectUserConnect(String login, String password);
    }
}