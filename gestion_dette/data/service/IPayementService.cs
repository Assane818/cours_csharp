using GesDette.Data.Entities;

namespace GesDette.Data.Service
{
    public interface IPayementService : IService<Payement>
    {
        List<Payement> ShowPayementsInDette(Dette dette);
    }
}