using GesDette.Core.Repository.Impl;
using GesDette.Data.Entities;

namespace GesDette.Data.Repository.Impl
{
    public class DetailRepositoryImplList : RepositoryImplList<Detail>, IDetailRepository
    {
        private IDetteRepository detteRepository;

        public Detail SelectById(int id)
        {
            return list.Find(detail => detail.Id == id);
        }

        public List<Detail> SelectDetailsInDette(Dette dette)
        {
            return dette.Details;
        }

        public void UpdateDetteId(Detail detail, int id)
        {
            detail.Dette = detteRepository.SelectById(id);
        }
    }
}