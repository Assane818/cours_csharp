using GesDette.Core.Repository.Impl;
using GesDette.Data.Entities;
using GesDette.Data.Enums;

namespace GesDette.Data.Repository.Impl
{
    public class DetteRepositoryImplList : RepositoryImplList<Dette>, IDetteRepository
    {
        public Dette SelectById(int id)
        {
            return list.Find(dette => dette.Id == id);
        }

        public List<Dette> SelectDettesByEtat(Etat etat)
        {
            return list.Where(dette => dette.Etat == etat).ToList();
        }

        public List<Dette> SelectDettesNoSoldeClient(Client client)
        {
            return list.Where(dette => dette.Client.Id == client.Id && dette.Montant > dette.MontantVerser).ToList();
        }

        public void UpdateDette(Dette dette)
        {
            foreach (var det in list)
            {
                if (det.Id == dette.Id) {
                    det.Etat = dette.Etat;
                    det.Montant = dette.Montant;
                    break;
                }
            }
        }

        public void UpdateEtatDette(Dette dette, Etat etat)
        {
            dette.Etat = etat;
        }
    }
}