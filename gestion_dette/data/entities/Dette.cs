using GesDette.Data.entities;
using GesDette.Data.Enums;

namespace GesDette.Data.Entities
{
    public class Dette : AbstractEntity {

        public DateTime Date {get; set;}
        public double Montant {get; set;}
        public double MontantVerser {get; set;}
        public Client Client {get; set;}
        public Etat Etat {get; set;}
        public List<Detail> Details {get; set;}
        public List<Payement> Payements {get; set;}

        public override string ToString() {
            return "Dette[" +
                    "id=" + Id +
                    ", date=" + Date +
                    ", montant=" + Montant +
                    ", montantVerser=" + MontantVerser +
                    ", client=" + Client +
                    ", etat=" + Etat + ']';
        }

        public bool equals(Dette obj) {
            if (this == obj) return true;
            if (obj == null) return false;
            Dette dette = (Dette) obj;
            return Id == dette.Id &&
                    object.Equals(Date, dette.Date) &&
                    object.Equals(Montant, dette.Montant) &&
                    object.Equals(MontantVerser, dette.MontantVerser) &&
                    object.Equals(Client, dette.Client) &&
                    object.Equals(Etat, dette.Etat);  
        }
    }
}