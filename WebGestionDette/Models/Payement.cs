namespace WebGestionDette.Models
{
    public class Payement : AbstractEntity {

        public DateTime Date {get; set;}
        public double MontantPayer {get; set;}
        public Dette Dette {get; set;}
        public int detteId {get; set;}
    }
}