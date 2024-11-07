using GesDette.Core.Repository;
using GesDette.Data.Entities;
using GesDette.Data.Enums;

namespace GesDette.Data.Repository
{
    public interface IDetteRepository : IRepository<Dette>
    {
        List<Dette> SelectDettesNoSoldeClient(Client client);
        List<Dette> SelectDettesByEtat(Etat etat);
        void UpdateEtatDette(Dette dette, Etat etat);
        void UpdateDette(Dette dette);
        Dette SelectById(int id);
    }
}