using GesDette.Data.entities;

namespace GesDette.Data.Entities
{
    public class Payement : AbstractEntity {

        public DateTime Date {get; set;}
        public double MontantPayer {get; set;}
        public Dette Dette {get; set;}

        public override string ToString() {
            return $"Payement n°{Id}, date : {Date.ToShortDateString()}, montant : {MontantPayer} ���";
        }
        public bool Equals(Payement obj) {
            if (this == obj) return true;
            if (obj == null) return false;
            Payement payement = (Payement) obj;
            return Id == payement.Id &&
                    object.Equals(Date, payement.Date) &&
                    object.Equals(MontantPayer, payement.MontantPayer) &&
                    object.Equals(Dette, payement.Dette); 
        }
    }
}