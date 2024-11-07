using GesDette.Data.entities;
using GesDette.Data.Enums;

namespace GesDette.Data.Entities
{
    public class Dette : AbstractEntity {
        private int id;
        private DateTime date;
        private double montant;
        private double montantVerser;
        private Client client;
        private Etat etat;
        private static int nbreDette;
        private List<Detail> details = new List<Detail>();
        private List<Payement> payements = new List<Payement>();


        public Dette() {
            nbreDette++;
            id = nbreDette;
            etat = Etat.ENCOURS;
        }

        public int Id {get => id; set => id = value;}
        public DateTime Date {get => date; set => date = value;}
        public double Montant {get => montant; set => montant = value;}
        public double MontantVerser {get => montantVerser; set => montantVerser = value;}
        public Client Client {get => client; set => client = value;}
        public Etat Etat {get => etat; set => etat = value;}
        public List<Detail> Details {get => details; set => details = value;}
        public List<Payement> Payements {get => payements; set => payements = value;}

        public override string ToString() {
            return "Dette[" +
                    "id=" + id +
                    ", date=" + date +
                    ", montant=" + montant +
                    ", montantVerser=" + montantVerser +
                    ", client=" + client +
                    ", etat=" + etat + ']';
        }

        public bool equals(Dette obj) {
            if (this == obj) return true;
            if (obj == null) return false;
            Dette dette = (Dette) obj;
            return id == dette.id &&
                    object.Equals(date, dette.date) &&
                    object.Equals(montant, dette.montant) &&
                    object.Equals(montantVerser, dette.montantVerser) &&
                    object.Equals(client, dette.client) &&
                    object.Equals(etat, dette.etat);  
        }
    }
}