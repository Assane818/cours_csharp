using GesDette.Core.Repository;
using GesDette.Data.Entities;

namespace GesDette.Data.Repository
{
    public interface IArticleRepository : IRepository<Article>
    {
        List<Article> FindAllByDisponiblity();
        void Update(Article article, double quantite);
        Article SelectByLibelle(String libelle);
        Article SelectArticleInDetail(Detail detail);
        Article SelectById(int id);
    }
}