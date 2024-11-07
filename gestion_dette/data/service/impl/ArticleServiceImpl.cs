using GesDette.Data.Entities;
using GesDette.Data.Repository;

namespace GesDette.Data.Service.Impl
{
    public class ArticleServiceImpl : IArticleService
    {
        private IArticleRepository articleRepository;
        
        public ArticleServiceImpl(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }
        public string GenerateReference(int nbr, string format)
        {
            throw new NotImplementedException();
        }

        public Article GetArticleInDetail(Detail detail)
        {
            return articleRepository.SelectArticleInDetail(detail);
        }

        public List<Article> GetByDisponiblity()
        {
            return articleRepository.FindAllByDisponiblity();
        }

        public Article GetById(int id)
        {
            return articleRepository.SelectById(id);
        }

        public Article GetByLibelle(string libelle)
        {
            return articleRepository.SelectByLibelle(libelle);
        }

        public int Save(Article entity)
        {
            return articleRepository.Insert(entity);
        }

        public List<Article> Show()
        {
            return articleRepository.SelectAll();
        }

        public void Update(Article article, double quantite)
        {
            articleRepository.Update(article, quantite);
        }
    }
}