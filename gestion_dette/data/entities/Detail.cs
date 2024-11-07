using GesDette.Data.entities;

namespace GesDette.Data.Entities
{
    public class Detail : AbstractEntity {
        private double quantite;
        private Article article;
        private Dette dette;
        private static int nbreDetail;

        public Detail() {
            nbreDetail++;
            id = nbreDetail;
        }
        public int Id {get => id; set => id = value;}
        public double Quantite {get => quantite; set => quantite = value;}
        public Article Article {get => article; set => article = value;}
        public Dette Dette {get => dette; set => dette = value;}

        public override string ToString() {
            return $"Detail {Id} : {Quantite} {Article.Libelle} pour la dette {Dette.Id}";
        }
    }
}