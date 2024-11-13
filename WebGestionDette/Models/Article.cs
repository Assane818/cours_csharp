using System.ComponentModel.DataAnnotations;

namespace WebGestionDette.Models
{
    public class Article : AbstractEntity {
        [Required(ErrorMessage = "Le libellé est obligatoire")]
        public string Libelle {get; set;}
        [Required(ErrorMessage = "Le prix est obligatoire")]
        [Range(1, double.MaxValue, ErrorMessage = "Seul un montant positif est autorisé")]
        public double Prix {get; set;}
        [Required(ErrorMessage = "La quantité est obligatoire")]
        [Range(1, int.MaxValue, ErrorMessage = "Seul un nombre entier positif est autorisé")]
        public double Quantite {get; set;}
        public ICollection<Detail> Details {get; set;}

    }
}
