using GesDette.Core.Controllers;
using GesDette.Data.Entities;
using GesDette.Data.Enums;
using GesDette.Data.Service;
using GesDette.Views;

namespace GesDette.Data.Controllers
{
    public class ClientController : Controller
    {
        private IClientService clientService;
        private IClientView clientView;
        private IDetteService detteService;
        private IDetteView detteView;
        private IDetailService detailService;
        private IDetailView detailView;
        private IPayementService payementService;
        private IPayementView payementView;

        public ClientController(IClientService clientService, IClientView clientView, IDetteService detteService, IDetteView detteView, IDetailService detailService, IDetailView detailView, IPayementService payementService, IPayementView payementView)
        {
            this.clientService = clientService;
            this.clientView = clientView;
            this.detteService = detteService;
            this.detteView = detteView;
            this.detailService = detailService;
            this.detailView = detailView;
            this.payementService = payementService;
            this.payementView = payementView;
        }
        public void run(int choix)
        {
            Client client2 = clientService.GetByUser(UserConnect.GetUserConnect());
            if (client2 == null) {
                Console.WriteLine("Le client n'existe pas");
                return;
            }
            switch (choix)
            {
                case 1:
                    List<Dette> dettesNoSolde = detteService.ShowDettesNoSoldeClient(client2);
                    detteView.Affiche(dettesNoSolde);
                    int choice = detteView.ChoiceFilter(["Article", "Payement"]);
                    switch (choice) {
                        case 1:
                            Dette dette1 = detteService.GetById(clientView.SaisieInt("Entrer l'id de la dette"));
                            if (dette1 == null || dette1.Client.Id != client2.Id) {
                                Console.WriteLine("la dette n'existe pas");
                                break;
                            }
                            detailView.Affiche(detailService.ShowDetailsInDette(dette1));
                            break;
                        case 2:
                            Dette dette2 = detteService.GetById(clientView.SaisieInt("Entrer l'id de la dette"));
                            if (dette2 == null || dette2.Client.Id != client2.Id) {
                                Console.WriteLine("la dette n'existe pas");
                                break;
                            }
                            payementView.Affiche(payementService.ShowPayementsInDette(dette2));
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
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
                case 3:
                    List<Dette> dettes = detteService.GetDettesByEtat(detteView.SaisieEtat());
                    detteView.Affiche(detteService.GetDettesByClient(dettes, client2));
                    break;
                case 4:
                    detteView.Affiche(detteService.GetDettesByEtat(Etat.REFUSER));
                    Dette dette3 = detteService.GetById(clientView.SaisieInt("Entrer l'id de la dette a relancer"));
                    if (dette3 == null || dette3.Client.Id != client2.Id && dette3.Etat != Etat.REFUSER) {
                        Console.WriteLine("la dette n'existe pas ou n'a pas ete refuser");
                        break;
                    }
                    detteService.UpdateEtatDette(dette3, Etat.ENCOURS);
                    break;
                default:
                    break;
            }
        }

        public int showMenu()
        {
            Console.WriteLine("1-lister mes dettes non solde");
            Console.WriteLine("2-Creer une dette");
            Console.WriteLine("3-Lister les dettes par etat");
            Console.WriteLine("4-Envoyer une relance pour une  demande de dette annuler");
            Console.WriteLine("5-Deconnexion");
            Console.WriteLine("Entrer votre choix");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}