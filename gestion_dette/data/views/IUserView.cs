using GesDette.Data.Entities;
using GesDette.Data.Enums;

namespace GesDette.Views
{
    public interface IUserView : IView<User>
    {
        Role SaisieRole();
        Role SaisieAllRole();
        bool SaisieEtat();
        User SaisieBoutiquierOrAdmin(Role role);
        User SaisieConnexion();
    }
}