using GesDette.Data.entities;

namespace GesDette.Data.Entities
{
    public class Payement : AbstractEntity {
        private DateTime date;
        private double montantPayer;
        private Dette dette;
        private static int nbrePayement;

        public Payement() {
            nbrePayement++;
            id = nbrePayement;
        }

        public int Id {get => id; set => id = value;}
        public DateTime Date {get => date; set => date = value;}
        public double MontantPayer {get => montantPayer; set => montantPayer = value;}
        public Dette Dette {get => dette; set => dette = value;}

        public override string ToString() {
            return $"Payement n°{id}, date : {date.ToShortDateString()}, montant : {montantPayer} ���";
        }
        public bool Equals(Payement obj) {
            if (this == obj) return true;
            if (obj == null) return false;
            Payement payement = (Payement) obj;
            return id == payement.id &&
                    object.Equals(date, payement.date) &&
                    object.Equals(montantPayer, payement.montantPayer) &&
                    object.Equals(dette, payement.dette);  
        }
    }
}