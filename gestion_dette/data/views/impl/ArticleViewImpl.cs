using GesDette.Data.Entities;
using GesDette.Data.Service;

namespace GesDette.Views.Impl
{
    public class ArticleViewImpl : ViewImpl<Article>, IArticleView
    {
        private IArticleService articleService;
        public ArticleViewImpl(IArticleService articleService)
        {
            this.articleService = articleService;
        }
        public override Article Saisie()
        {
            Article article = new();
            do {
                Console.WriteLine("Saisir le libelle de l'article");
                article.Libelle = Console.ReadLine();
            } while (String.IsNullOrEmpty(article.Libelle) || articleService.GetByLibelle(article.Libelle) != null);
            Console.WriteLine("Saisir le prix de l'article");
            article.Prix = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Saisir la quantite de l'article");
            article.Quantite = Convert.ToDouble(Console.ReadLine());
            return article;
        }
    }
}