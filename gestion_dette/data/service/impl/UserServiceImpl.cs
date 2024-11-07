using GesDette.Data.Entities;
using GesDette.Data.Enums;
using GesDette.Data.Repository;

namespace GesDette.Data.Service.Impl
{
    public class UserServiceImpl : IUserService
    {
        private IUserRepository userRepository;
        public UserServiceImpl(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User GetById(int id)
        {
            return userRepository.SelectById(id);
        }

        public User GetByLogin(string login)
        {
            return userRepository.SelectByLogin(login);
        }

        public List<User> GetUsersByEtat()
        {
            return userRepository.SelectAllUsersByEtat();
        }

        public List<User> GetUsersByRole(Role role)
        {
            return userRepository.SelectAllUsersByRole(role);
        }

        public int Save(User entity)
        {
            return userRepository.Insert(entity);
        }

        public User SelectUserConnect(string login, string password)
        {
            return userRepository.SelectUserConnect(login, password);
        }

        public List<User> Show()
        {
            return userRepository.SelectAll();
        }

        public bool UpdateEtat(User user, bool etat)
        {
            return userRepository.UpdateEtat(user, etat);
        }
    }
}