using WebGestionDette.Validator;

namespace WebGestionDette.Models
{
    public class Payement : AbstractEntity {

        public DateTime Date {get; set;} = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
        [MontantPayer]
        public double MontantPayer {get; set;}
        public Dette Dette {get; set;}
        public int detteId {get; set;}
    }
}