using GesDette.Data.Entities;

namespace GesDette.Data.Service
{
    public interface IArticleService : IService<Article>
    {
        List<Article> GetByDisponiblity();
        void Update(Article article, double quantite);
        String GenerateReference(int nbr,String format);
        Article GetByLibelle(String libelle);
        Article GetArticleInDetail(Detail detail);
    }
}