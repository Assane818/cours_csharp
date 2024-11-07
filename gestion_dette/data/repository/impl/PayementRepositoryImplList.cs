using GesDette.Core.Repository.Impl;
using GesDette.Data.Entities;
using GesDette.Data.Repository;

namespace GesDette.data.repository.impl
{
    public class PayementRepositoryImplList : RepositoryImplList<Payement>, IPayementRepository
    {
        public Payement SelectById(int id)
        {
            return list.Find(payement => payement.Id == id);
        }

        public List<Payement> selectPayementsInDette(Dette dette)
        {
            return list.Where(payement => payement.Dette.Id == dette.Id).ToList();
        }
    }
}