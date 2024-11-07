using GesDette.Core.Repository;
using GesDette.Data.Entities;

namespace GesDette.Data.Repository
{
    public interface IPayementRepository : IRepository<Payement> {
        List<Payement> selectPayementsInDette(Dette dette);
        Payement SelectById(int id);
    }
}