using GesDette.Data.Entities;
using GesDette.Data.Repository;

namespace GesDette.Data.Service.Impl
{
    public class PayementServiceImpl : IPayementService
    {
        private IPayementRepository payementRepository;
        public PayementServiceImpl(IPayementRepository payementRepository)
        {
            this.payementRepository = payementRepository;
        }
        public Payement GetById(int id)
        {
            return payementRepository.SelectById(id);
        }

        public int Save(Payement entity)
        {
            return payementRepository.Insert(entity);
        }

        public List<Payement> Show()
        {
            return payementRepository.SelectAll();
        }

        public List<Payement> ShowPayementsInDette(Dette dette)
        {
            return payementRepository.selectPayementsInDette(dette);
        }
    }
}