using GesDette.Core.Controllers;
using GesDette.Data.Entities;
using GesDette.Data.Enums;
using GesDette.Data.Service;

namespace GesDette.Views.Impl
{
    partial class DetteViewImpl : ViewImpl<Dette>, IDetteView
    {
        private IClientService clientService;
        private IArticleService articleService;

        public DetteViewImpl(IClientService clientService, IArticleService articleService) {
            this.clientService = clientService;
            this.articleService = articleService;
        }
        public override Dette? Saisie()
        {
           Dette dette = new Dette();
        if (UserConnect.GetUserConnect().Role != Role.CLIENT) {
            Client client = clientService.GetById(SaisieInt("Entrer l'id du client"));
            dette.Client = client;
            dette.Etat = Etat.VALIDER;
            if (client == null) {
                return null;
            }
            client.Dettes.Add(dette);
        } else {
            dette.Client = clientService.GetByUser(UserConnect.GetUserConnect());
            clientService.GetByUser(UserConnect.GetUserConnect()).Dettes.Add(dette);
        }
        char reponse;
        do {
            Article article;
            do {
                article = articleService.GetByLibelle(SaisieString("Saisir le libelle de l'article"));
            } while (article == null);
            
            Detail detail = new();
            do {
                detail.Quantite = SaisieDouble("Saisir la quantite de l'article");
            } while (detail.Quantite > article.Quantite);
            dette.Montant = dette.Montant + (article.Prix * detail.Quantite);
            if (UserConnect.GetUserConnect().Role == Role.BOUTIQUIER) {
                articleService.Update(article, article.Quantite - detail.Quantite);
                dette.Etat = Etat.VALIDER;
            }
            detail.Article = article;
            dette.Details.Add(detail);
            detail.Dette = dette;
            Console.WriteLine("Voulez-vous ajouter un autre article O/N?");
            reponse = Console.ReadKey().KeyChar;
        } while (reponse == 'O' || reponse == 'o');
        return dette;
        }

        public Etat SaisieEtat()
        {
            int etatChoice;
            do {
                foreach (Etat etat in Enum.GetValues(typeof(Etat))) {
                    Console.WriteLine(Array.IndexOf(Enum.GetValues(etat.GetType()), etat) + 1 + "-" + etat.ToString());
                }
                Console.WriteLine("Entrer votre choix:");
                etatChoice = Convert.ToInt32(Console.ReadLine());
            } while (etatChoice <= 0 || etatChoice > Enum.GetValues(typeof(Etat)).Length);
            return (Etat)Enum.GetValues(typeof(Etat)).GetValue(etatChoice - 1);
        }
    }
}