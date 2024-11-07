using GesDette.Data.Entities;
using GesDette.Data.Enums;

namespace GesDette.Data.Service
{
    public interface IDetteService : IService<Dette>
    {
        List<Dette> ShowDettesNoSoldeClient(Client client);
        List<Dette> GetDettesByEtat(Etat etat);
        void UpdateEtatDette(Dette dette, Etat etat);
        void UpdateDette(Dette dette);
        List<Dette> GetDettesByClient(List<Dette> dettes, Client client);
        void ArchiverDettesSolde(List<Dette> dettes);
    }
}