using GesDette.Data.Entities;

namespace GesDette.Views
{
    public interface IPayementView : IView<Payement>
    {
        Payement SaisiePayement(Dette dette);
    }
}
