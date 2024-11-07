using GesDette.Data.Entities;
using GesDette.Data.Enums;

namespace GesDette.Views
{
    public interface IDetteView : IView<Dette>
    {
        Etat SaisieEtat();
    }
}