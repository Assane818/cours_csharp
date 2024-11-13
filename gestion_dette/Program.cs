using GesDette.Core.Controllers;
using GesDette.Core.Db;
using GesDette.Core.Service;
using GesDette.data.repository.impl;
using GesDette.Data.Controllers;
using GesDette.Data.Entities;
using GesDette.Data.Enums;
using GesDette.Data.Repository;
using GesDette.Data.Repository.Dapper;
using GesDette.Data.Repository.Db;
using GesDette.Data.Repository.EntityFramework;
using GesDette.Data.Repository.Impl;
using GesDette.Data.Service;
using GesDette.Data.Service.Impl;
using GesDette.Views;
using GesDette.Views.Impl;

namespace GesDette 
{
    internal class Program {
        static void Main(string[] args) {
            IDataBase dataBase = new DataBase();
            IUserRepository userRepository = new UserRepositoryImplEf();
            IClientRepository clientRepository = new ClientRepositoryImplEf();
            IArticleRepository articleRepository = new ArticleRepositoryImplList();
            IPayementRepository payementRepository = new PayementRepositoryImplList();
            IDetteRepository detteRepository = new DetteRepositoryImplList();
            IDetailRepository detailRepository = new DetailRepositoryImplList();

            IUserService userService = new UserServiceImpl(userRepository);
            IClientService clientService = new ClientServiceImpl(clientRepository);
            IArticleService articleService = new ArticleServiceImpl(articleRepository);
            IPayementService payementService = new PayementServiceImpl(payementRepository);
            IDetteService detteService = new DetteserviceImpl(detteRepository);
            IDetailService detailService = new DetailServiceImpl(detailRepository);

            IUserView userView = new UserViewImpl(userService);
            IClientView clientView = new ClientViewImpl(clientService);
            IArticleView articleView = new ArticleViewImpl(articleService);
            IPayementView payementView = new PayementViewImpl();
            IDetteView detteView = new DetteViewImpl(clientService, articleService);
            IDetailView detailView = new DetailViewImpl();


            do {
                User userConnect = userView.SaisieConnexion();
                if (userConnect == null) {
                    Console.WriteLine("Login ou mot de passe invalide");
                    continue;
                }
                UserConnect.SetUserConnect(userConnect);
                int choix;
                switch (userConnect.Role) {
                    case Role.ADMIN:
                        AdminController adminController = new(clientView, clientService, userService, userView, articleService, articleView, detteService);
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("BIENVENUE CHER ADMIN");
                        Console.WriteLine("-------------------------");
                        do {
                            choix = adminController.showMenu();
                            adminController.run(choix);
                        } while (choix != 10);
                        break;
                    case Role.CLIENT:
                        ClientController clientController = new(clientService, clientView, detteService, detteView, detailService, detailView, payementService, payementView);
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("BIENVENUE CHER CLIENT");
                        Console.WriteLine("-------------------------");
                        do {
                            Console.WriteLine(UserConnect.GetUserConnect());
                            choix = clientController.showMenu();
                            clientController.run(choix);
                        } while (choix != 5);
                        break;
                    case Role.BOUTIQUIER:
                        BoutiquierController boutiquierController = new(userView, userService, clientView, clientService, detailService, detteView, detteService, payementView, payementService, detailView, articleService);
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("BIENVENUE CHER BOUTIQUIER");
                        Console.WriteLine("-------------------------");
                        do {
                            choix = boutiquierController.showMenu();
                            boutiquierController.run(choix);
                        } while (choix != 9);
                        break;
                    default:
                        break;
                }

                // Déconnexion de l'utilisateur
                UserConnect.SetUserConnect(null);
                Console.WriteLine("Vous avez été déconnecté.");
            } while (true);
        }
    }
}