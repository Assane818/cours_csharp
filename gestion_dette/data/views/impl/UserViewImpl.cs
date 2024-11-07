using GesDette.Data.Entities;
using GesDette.Data.Enums;
using GesDette.Data.Service;

namespace GesDette.Views.Impl
{
    public class UserViewImpl : ViewImpl<User>, IUserView
    {
        private IUserService userService;

        public UserViewImpl(IUserService userService)
        {
            this.userService = userService;
        }
        public override User Saisie()
        {
            User user = new();
            Console.WriteLine("Saisir le nom de l'utilisateur");
            user.Nom = Console.ReadLine();
            Console.WriteLine("Saisir le prenom de l'utilisateur");
            user.Prenom = Console.ReadLine();
            do {
                Console.WriteLine("Saisir le login de l'utilisateur");
                user.Login = Console.ReadLine() ?? string.Empty;
            } while (userService.GetByLogin(user.Nom) != null);
            Console.WriteLine("Saisir le mot de passe de l'utilisateur");
            user.Password = Console.ReadLine();
            user.Role = Role.CLIENT;
            return user;
        }

        public Role SaisieAllRole()
        {
            int RoleChoice;
            do {
                int index = 1;
                foreach (Role role in Enum.GetValues(typeof(Role))) {
                    Console.WriteLine(index + "-" + role.ToString());
                    index++;
                }
                Console.WriteLine("Vous rechercher quelle role:");
                RoleChoice = Convert.ToInt32(Console.ReadLine());

            } while (RoleChoice <= 0 || RoleChoice > Enum.GetValues(typeof(Role)).Length);
            return (Role)Enum.GetValues(typeof(Role)).GetValue(RoleChoice - 1);
        }

        public User SaisieBoutiquierOrAdmin(Role role)
        {
            User user = new();
            Console.WriteLine("Saisir le nom de l'utilisateur");
            user.Nom = Console.ReadLine();
            Console.WriteLine("Saisir le prenom de l'utilisateur");
            user.Prenom = Console.ReadLine();
            do {
                Console.WriteLine("Saisir le login de l'utilisateur");
                user.Login = Console.ReadLine() ?? string.Empty;
            } while (userService.GetByLogin(user.Nom) != null);
            Console.WriteLine("Saisir le mot de passe de l'utilisateur");
            user.Password = Console.ReadLine();
            user.Role = role;
            return user;
        }

        public User SaisieConnexion()
        {
            Console.WriteLine("Saisir le login de l'utilisateur");
            String login = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Saisir le mot de passe de l'utilisateur");
            String password = Console.ReadLine() ?? string.Empty;
            return userService.SelectUserConnect(login, password);
        }

        public bool SaisieEtat()
        {
            int etatChoice;
            do
            {
                Console.WriteLine("1-Actif");
                Console.WriteLine("2-Inactif");
                Console.WriteLine("Entrer votre choix:");
                etatChoice = Convert.ToInt32(Console.ReadLine());
            } while (etatChoice <= 0 || etatChoice > 2);
            return etatChoice == 1;
        }

        public Role SaisieRole()
        {
            int RoleChoice;
            do {
                for (int i = 0; i < Enum.GetValues(typeof(Role)).Length - 1; i++) {
                    Role role = (Role)Enum.GetValues(typeof(Role)).GetValue(i);
                    Console.WriteLine(Array.IndexOf(Enum.GetValues(role.GetType()), role) + 1 + "-" + role.ToString());
                }
                Console.WriteLine("Vous voulez creer quelle role:");
                RoleChoice = Convert.ToInt32(Console.ReadLine());

            } while (RoleChoice <= 0 || RoleChoice > Enum.GetValues(typeof(Role)).Length - 1);
            return (Role)Enum.GetValues(typeof(Role)).GetValue(RoleChoice - 1);
            }
    }
}