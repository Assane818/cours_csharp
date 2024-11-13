using GesDette.Data.entities;

namespace GesDette.Data.Entities
{
    public class Article : AbstractEntity {

        public string Libelle {get; set;}
        public double Prix {get; set;}
        public double Quantite {get; set;}
        public List<Detail> Details {get; set;}

        public override string ToString() {
            return "Article[" +
                    "id=" + Id +
                    ", libelle='" + Libelle + '\'' +
                    ", prix=" + Prix +
                    ", quantite=" + Quantite + ']';
        }

        public bool equals(Article obj) {
            if (this == obj) return true;
            if (obj == null) return false;
            Article article = (Article) obj;
            return Id == article.Id &&
                    object.Equals(Libelle, article.Libelle) &&
                    object.Equals(Prix, article.Prix) &&
                    object.Equals(Quantite, article.Quantite); 
        }

    }
}
