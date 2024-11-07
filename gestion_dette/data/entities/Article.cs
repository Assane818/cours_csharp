using GesDette.Data.entities;

namespace GesDette.Data.Entities
{
    public class Article : AbstractEntity {
        private String libelle;
        private double prix;
        private double quantite;
        private static int nbreArticle;
        private List<Detail> details = new List<Detail>();

        public Article() {
            nbreArticle++;
            id = nbreArticle;
        }

        public int Id {get => id; set => id = value;}
        public string Libelle {get => libelle; set => libelle = value;}
        public double Prix {get => prix; set => prix = value;}
        public double Quantite {get => quantite; set => quantite = value;}
        public List<Detail> Details {get => details; set => details = value;}

        public override string ToString() {
            return "Article[" +
                    "id=" + id +
                    ", libelle='" + libelle + '\'' +
                    ", prix=" + prix +
                    ", quantite=" + quantite + ']';
        }

        public bool equals(Article obj) {
            if (this == obj) return true;
            if (obj == null) return false;
            Article article = (Article) obj;
            return id == article.id &&
                    object.Equals(libelle, article.libelle) &&
                    object.Equals(prix, article.prix) &&
                    object.Equals(quantite, article.quantite); 
        }

    }
}