using GesDette.Core.Repository.Impl;
using GesDette.Data.Entities;
using GesDette.Data.Enums;

namespace GesDette.Data.Repository.Impl
{
    public class UserRepositoryImplList : RepositoryImplList<User>, IUserRepository
    {
        public UserRepositoryImplList() {
            User user = new()
            {
                Nom = "ADMIN",
                Prenom = "ADMIN",
                Login = "ad@gmail.com",
                Password = "passer",
                Role = Role.ADMIN
            };
            User user1 = new()
            {
                Nom = "B",
                Prenom = "B",
                Login = "b@gmail.com",
                Password = "passer",
                Role = Role.BOUTIQUIER
            };
            User user2 = new()
            {
                Nom = "ndiaye",
                Prenom = "assane",
                Login = "a@gmail.com",
                Password = "passer",
                Role = Role.CLIENT
            };
            list.Add(user);
            list.Add(user1);
            list.Add(user2);
        }
        public List<User> SelectAllUsersByEtat()
        {
            return list.Where(user => user.Etat).ToList();
        }

        public List<User> SelectAllUsersByRole(Role role)
        {
            return list.Where(user => user.Role.CompareTo(role) == 0).ToList();
        }

        public User SelectById(int id)
        {
            User user = list.Find(user => user.Id == id);
            if (user == null)
            {
                Console.WriteLine($"Utilisateur avec l'ID {id} non trouvé.");
            }
            return user;
        }

        public User SelectByLogin(String login)
        {
            return list.Find(user => user.Login.CompareTo(login) == 0);
        }

        public User SelectUserConnect(String login, String password)
        {
            return list.Find(user => user.Login.CompareTo(login) == 0 && user.Password.CompareTo(password) == 0);
        }

        public bool UpdateEtat(User user, bool etat)
        {
            user.Etat = etat;
            return true;
        }
    }
}