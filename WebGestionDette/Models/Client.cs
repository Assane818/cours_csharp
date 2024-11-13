
using System.ComponentModel.DataAnnotations;

namespace WebGestionDette.Models
{
    public class Client : AbstractEntity {
        [Required(ErrorMessage = "Le surnom est obligatoire")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Le surnom doit avoir au moins 5 caractères et inférieur à 20 caractères")]
        public string Surname {get; set;} 
        [Required(ErrorMessage = "Le téléphone est obligatoire")]
        [RegularExpression(@"^(77|78|76)[0-9]{7}$", ErrorMessage = "Le téléphone doit commencer par 77 ou 78 ou 76 et doit avoir au 9 chiffres")]
        public string Phone {get; set;}
        public string Address {get; set;}
        public User? User {get; set;}
        public int? UserId {get; set;}
        public ICollection<Dette> Dettes {get; set;}
    }
}