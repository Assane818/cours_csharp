using GesDette.Core.Repository.Impl;
using GesDette.Data.Entities;

namespace GesDette.Data.Repository.Impl
{
    public class ArticleRepositoryImplList : RepositoryImplList<Article>, IArticleRepository
    {
        public ArticleRepositoryImplList() {
            Article article = new() {
                Libelle = "Pain",
                Quantite = 50,
                Prix = 150
            };
            Article article1 = new() {
                Libelle = "Lait",
                Quantite = 0,
                Prix = 350
            };
            list.Add(article);
            list.Add(article1);

        }
        public List<Article> FindAllByDisponiblity()
        {
            return list.Where(Article => Article.Quantite > 0).ToList();
        }

        public Article SelectArticleInDetail(Detail detail)
        {   
            return list.Find(Article => Article.Id == detail.Article.Id);
        }

        public Article SelectById(int id)
        {
            return list.Find(Article => Article.Id == id);
        }

        public Article SelectByLibelle(string libelle)
        {
            return list.Find(Article => Article.Libelle.CompareTo(libelle) == 0);
        }

        public void Update(Article article, double quantite)
        {
            article.Quantite = quantite;
        }
    }
}