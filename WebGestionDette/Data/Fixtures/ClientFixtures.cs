using WebGestionDette.Models;
using WebGestionDette.Models.Enum;

namespace WebGestionDette.Data.Fixtures
{
    public class ClientFixtures
    {
        private readonly WebGesDetteContext _context;
        public ClientFixtures(WebGesDetteContext context)
        {
            _context = context;
        }
        public void LoadData()
        {
            if (!_context.Clients.Any())
            {


                var Clients = new List<Client>();
                var Dettes = new List<Dette>();

                for (int i = 1; i <= 25; i++)
                {
                    var user = new User
                    {
                        Nom = $"Nom {i}",
                        Prenom = $"Prenom {i}",
                        Login = $"user{i}@gmail.com",
                        Password = "passer",
                        Role = Role.CLIENT,
                    };

                    var client = new Client
                    {
                        Surname = $"Client {i}",
                        Address = $"Adresse {i}",
                        Phone = $"7712345{i:D2}",
                        User = i % 2 == 0 ? user : null
                    };

                    Clients.Add(client);

                    if (!_context.Dettes.Any())
                    {


                        if (i % 2 == 0)
                        {
                            var dette = new Dette
                            {
                                Date = DateTime.Now.ToUniversalTime(),
                                Montant = 1000 * i,
                                MontantVerser = 0,
                                Etat = Etat.ENCOURS,
                                Client = client
                            };
                            Dettes.Add(dette);
                        }
                    }
                }

                var Articles = new List<Article>(){

          new Article{Libelle = "Article 1", Prix = 1000, Quantite = 10},
          new Article{Libelle = "Article 2", Prix = 2000, Quantite = 20},
          new Article{Libelle = "Article 3", Prix = 3000, Quantite = 30},
          new Article{Libelle = "Article 4", Prix = 4000, Quantite = 40},
          new Article{Libelle = "Article 5", Prix = 5000, Quantite = 50},
          new Article{Libelle = "Article 6", Prix = 6000, Quantite = 60},
          new Article{Libelle = "Article 7", Prix = 7000, Quantite = 70},
          new Article{Libelle = "Article 8", Prix = 8000, Quantite = 80},
          new Article{Libelle = "Article 9", Prix = 9000, Quantite = 90},
          new Article{Libelle = "Article 10", Prix = 10000, Quantite = 100},
        };

                _context.Articles.AddRange(Articles);
                _context.Clients.AddRange(Clients);
                _context.Dettes.AddRange(Dettes);
                _context.SaveChanges();
            }

        }
    }
}