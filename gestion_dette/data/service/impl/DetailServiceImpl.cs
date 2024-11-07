using GesDette.Data.Entities;
using GesDette.Data.Repository;

namespace GesDette.Data.Service
{
    public class DetailServiceImpl : IDetailService
    {
        private IDetailRepository detailRepository;

        public DetailServiceImpl(IDetailRepository detailRepository)
        {
            this.detailRepository = detailRepository;
        }
        public Detail GetById(int id)
        {
            return detailRepository.SelectById(id);
        }

        public int Save(Detail entity)
        {
            return detailRepository.Insert(entity);
        }

        public List<Detail> Show()
        {
            return detailRepository.SelectAll();
        }

        public List<Detail> ShowDetailsInDette(Dette dette)
        {
            return detailRepository.SelectDetailsInDette(dette);
        }

        public void UpdateDetteId(Detail detail, int id)
        {
            detailRepository.UpdateDetteId(detail, id);
        }
    }
}