using GesDette.Data.entities;

namespace GesDette.Data.Entities
{
    public class Detail : AbstractEntity {

        public double Quantite {get; set;}
        public Article Article {get; set;}
        public Dette Dette {get; set;}

        public override string ToString() {
            return $"Detail {Id} : {Quantite} {Article.Libelle} pour la dette {Dette.Id}";
        }
    }
}