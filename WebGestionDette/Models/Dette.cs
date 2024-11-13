
using System.ComponentModel.DataAnnotations;
using WebGestionDette.Models.Enum;

namespace WebGestionDette.Models
{
    public class Dette : AbstractEntity {
        public DateTime Date {get; set;}
        [Required(ErrorMessage = "Le montant est obligatoire")]
        [Range(1, double.MaxValue, ErrorMessage = "Seul un montant positif est autorisé")]
        public double Montant {get; set;}
        [Required(ErrorMessage = "Le montant versé est obligatoire")]
        [Range(0, double.MaxValue, ErrorMessage = "Seul un montant positif est autorisé")]
        public double MontantVerser {get; set;}
        public Client Client {get; set;}
        public Etat Etat {get; set;}
        public ICollection<Detail> Details {get; set;}
        public ICollection<Payement> Payements {get; set;}
        public int clientId {get; set;}
    }
}