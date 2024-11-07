using GesDette.Core.Controllers;
using GesDette.Data.Entities;
using GesDette.Data.Service;
using GesDette.Views;

namespace GesDette.Data.Controllers
{
    public class AdminController : Controller
    {
        private IClientView clientView;
        private IClientService clientService;
        private IUserService userService;
        private IUserView userView;
        private IArticleService articleService;
        private IArticleView articleView;
        private IDetteService detteService;

        public AdminController(IClientView clientView, IClientService clientService, IUserService userService, IUserView userView, IArticleService articleService, IArticleView articleView, IDetteService detteService)
        {
            this.clientView = clientView;
            this.clientService = clientService;
            this.userService = userService;
            this.userView = userView;
            this.articleService = articleService;
            this.articleView = articleView;
            this.detteService = detteService;
        }
        public void run(int choix)
        {
            switch (choix)
            {
                case 1:
                    Client client = clientService.GetByPhone(clientView.SaisieString("Entrer le numero de telephone"));
                    if (client == null || client.User != null) {
                        Console.WriteLine("Le client n'existe pas ou a deja un compte utilisateur");
                        break;
                    }
                    User user1 = userView.Saisie();
                    int id = userService.Save(user1);
                    client.User = user1;
                    break;
                case 2:
                    userService.Save(userView.SaisieBoutiquierOrAdmin(userView.SaisieRole()));
                    break;
                case 3:
                    userView.Affiche(userService.Show());
                    User user = userService.GetById(userView.SaisieInt("Enter l'id de l'utilisateur"));
                    if (user == null) {
                        Console.WriteLine("l'utilisateur n'existe pas");
                        break;
                    }
                    userService.UpdateEtat(user, userView.SaisieEtat());
                    break;
                case 4:
                    int filter;
                    do {
                        filter = userView.ChoiceFilter(["Actif", "Role"]);
                        switch (filter) {
                            case 1:
                                userView.Affiche(userService.GetUsersByEtat());
                                break;
                            case 2:
                                userView.Affiche(userService.GetUsersByRole(userView.SaisieAllRole()));
                                break;
                        }                    
                    } while (filter != 1 && filter != 2);
                    break;
                case 5:
                    articleService.Save(articleView.Saisie());
                    break;
                case 6:
                    articleView.Affiche(articleService.Show());
                    break;
                case 7:
                    articleView.Affiche(articleService.GetByDisponiblity());
                    break;
                case 8:
                    articleView.Affiche(articleService.Show());
                    Article article = articleService.GetByLibelle(articleView.SaisieString("Entrer le lebelle de l'article"));
                    if (article == null) {
                        Console.WriteLine("l'article n'existe pas");
                        break;
                    }
                    articleService.Update(article, articleView.SaisieDouble("Entrer la nouvelle quantité"));
                    break;
                case 9:
                    detteService.ArchiverDettesSolde(detteService.Show());
                    Console.WriteLine("Dette archivee avec succes");
                    break;

                default:
                    break;
            }
        }

        public int showMenu()
        {
            Console.WriteLine("1-Creer un compte utilisateur a un client");
            Console.WriteLine("2-Creer un compte utilisateur avec un role Boutiquier ou  Admin");
            Console.WriteLine("3-Désactiver/Activer  un compte utilisateur");
            Console.WriteLine("4-Afficher les comptes utilisateurs  actifs ou par role");
            Console.WriteLine("5-Créer un article");
            Console.WriteLine("6-lister les articles");
            Console.WriteLine("7-filtrer les articles par disponibilité");
            Console.WriteLine("8-Mettre à jour la qté en stock d’un article");
            Console.WriteLine("9-Archiver les dette solde");
            Console.WriteLine("10-Deconnexion");
            Console.WriteLine("Entrer votre choix");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}