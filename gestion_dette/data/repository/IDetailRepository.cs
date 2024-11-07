using GesDette.Core.Repository;
using GesDette.Data.Entities;

namespace GesDette.Data.Repository
{
    public interface IDetailRepository : IRepository<Detail>
    {
        void UpdateDetteId(Detail detail, int id);
        List<Detail>SelectDetailsInDette(Dette dette);
        Detail SelectById(int id);
    }
}