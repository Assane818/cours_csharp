using GesDette.Core.Controllers;
using GesDette.Data.Entities;
using GesDette.Data.Enums;
using GesDette.Data.Service;
using GesDette.Views;

namespace GesDette.Data.Controllers
{
    public class BoutiquierController : Controller
    {
        private IClientView clientView;
        private IUserView userView;
        private IUserService userService;
        private IClientService clientService;
        private IDetailService detailService;
        private IDetteView detteView;
        private IDetteService detteService;
        private IPayementView payementView;
        private IPayementService payementService;
        private IDetailView detailView;
        private IArticleService articleService;

        public BoutiquierController(IUserView userView, IUserService userService, IClientView clientView, IClientService clientService, IDetailService detailService, IDetteView detteView, IDetteService detteService, IPayementView payementView, IPayementService payementService, IDetailView detailView, IArticleService articleService)
        {
            this.userView = userView;
            this.userService = userService;
            this.clientView = clientView;
            this.clientService = clientService;
            this.detailService = detailService;
            this.detteView = detteView;
            this.detteService = detteService;
            this.payementView = payementView;
            this.payementService = payementService;
            this.detailView = detailView;
            this.articleService = articleService;
        }
        public void run(int choix)
        {
            switch (choix)
            {
                case 1:
                    Client client1 = clientView.Saisie();
                    Console.WriteLine("Voulez-vous ajouter un compte utilisateur O/N");
                    char rp = Console.ReadKey().KeyChar;
                    if (rp == 'O' || rp == 'o') {
                        User user = userView.Saisie();
                        int userId = userService.Save(user);
                        client1.User = user;
                    }
                    Console.WriteLine(client1);
                    clientService.Save(client1);
                    break;
                case 2:
                    clientView.Affiche(clientService.Show());
                    break;
                case 3:
                    Console.WriteLine(clientService.GetByPhone(clientView.SaisieString("Entrer le numero de telephone a rechercher")));
                    break;
                case 4:
                    clientView.Affiche(clientService.Show());
                    Dette dette = detteView.Saisie();
                    if (dette == null) {
                        break;
                    }
                    int id1 = detteService.Save(dette);
                    foreach (Detail detail in dette.Details) {
                        detail.Dette = dette;
                        detailService.Save(detail);
                    }
                    break;
                case 5:
                    detteView.Affiche(detteService.GetDettesByEtat(Etat.VALIDER));
                    Dette dette2 = detteService.GetById(detteView.SaisieInt("Entrer l'id de la dette a payer"));
                    if (dette2 == null || dette2.Etat != Etat.VALIDER || dette2.Montant == dette2.MontantVerser) {
                        Console.WriteLine("la dette n'existe pas ou n'est pas valider");
                        break;
                    }
                    Console.WriteLine(dette2);
                    Payement payement = payementView.SaisiePayement(dette2);
                    payementService.Save(payement);
                    detteService.UpdateDette(dette2);
                    break;

                case 6:
                    Client client2 = clientService.GetByPhone(clientView.SaisieString("Entrer le numero de telephone"));
                    if (client2 == null) {
                        Console.WriteLine("Le client n'existe pas");
                        break;
                    }
                    List<Dette> dettesNoSolde = detteService.ShowDettesNoSoldeClient(client2);
                    detteView.Affiche(dettesNoSolde);
                    int choice = detteView.ChoiceFilter(["Article", "Payement"]);
                    switch (choice) {
                        case 1:
                            Dette dette4 = detteService.GetById(clientView.SaisieInt("Entrer l'id de la dette"));
                            if (dette4 == null || dette4.Client.Id != client2.Id) {
                                Console.WriteLine("la dette n'existe pas");
                                break;
                            }
                            detailView.Affiche(detailService.ShowDetailsInDette(dette4));
                            break;
                        case 2:
                            Dette dette3 = detteService.GetById(clientView.SaisieInt("Entrer l'id de la dette"));
                            if (dette3 == null || dette3.Client.Id != client2.Id) {
                                Console.WriteLine("la dette n'existe pas");
                                break;
                            }
                            payementView.Affiche(payementService.ShowPayementsInDette(dette3));
                            break;
                    }
                    break;
                case 7:
                    detteView.Affiche(detteService.GetDettesByEtat(detteView.SaisieEtat()));
                    break;
                case 8:
                    detteView.Affiche(detteService.GetDettesByEtat(Etat.ENCOURS));
                    Dette dette1 = detteService.GetById(detteView.SaisieInt("Entrer l'id de la dette"));
                    if (dette1 == null || dette1.Etat != Etat.ENCOURS) {
                        Console.WriteLine("la dette n'existe pas");
                        break;
                    }
                    List<Detail> details = detailService.ShowDetailsInDette(dette1);
                    detailView.Affiche(details);
                    int choice1 = detteView.ChoiceFilter(["Valider", "Refuser"]);
                    switch (choice1) {
                        case 1:
                            detteService.UpdateEtatDette(dette1, Etat.VALIDER);
                            foreach (Detail detail in details) {
                                Article article = articleService.GetArticleInDetail(detail);
                                articleService.Update(article, article.Quantite - detail.Quantite);
                            }
                            break;
                        case 2:
                            detteService.UpdateEtatDette(dette1, Etat.REFUSER);
                            break;
                    }
                    break;
                    
                default:
                    break;
            }
        }

        public int showMenu()
        {
            Console.WriteLine("1-Creer un client");
            Console.WriteLine("2-lister client");
            Console.WriteLine("3-chercher un client par numero de telephone");
            Console.WriteLine("4-Creer une dette");
            Console.WriteLine("5-Enregistrer un payement");
            Console.WriteLine("6-lister dette non solde d'un client");
            Console.WriteLine("7-Lister les dettes par etat");
            Console.WriteLine("8-Traiter une demande de dette");
            Console.WriteLine("9-Deconnexion");
            Console.WriteLine("Entrer votre choix");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}