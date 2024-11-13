using System.ComponentModel.DataAnnotations;

namespace WebGestionDette.Models
{
    public class Detail : AbstractEntity {
        [Required(ErrorMessage = "Le montant est obligatoire")]
        [Range(1, float.MaxValue, ErrorMessage = "Seul un montant positif est autorisé")]
        public double Quantite {get; set;}
        public Article Article {get; set;}
        public Dette Dette {get; set;}
        public int articleId {get; set;}
        public int detteId {get; set;}
    }
}