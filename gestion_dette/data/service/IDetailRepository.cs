using GesDette.Data.Entities;

namespace GesDette.Data.Service
{
    public interface IDetailService : IService<Detail>
    {
        void UpdateDetteId(Detail detail, int id);
        List<Detail> ShowDetailsInDette(Dette dette);
    }
}