using GesDette.Data.Entities;
using GesDette.Data.Enums;
using GesDette.Data.Repository;

namespace GesDette.Data.Service.Impl
{
    public class DetteserviceImpl : IDetteService
    {
        private IDetteRepository detteRepository;
        public DetteserviceImpl(IDetteRepository detteRepository)
        {
            this.detteRepository = detteRepository;
        }
        public void ArchiverDettesSolde(List<Dette> dettes)
        {
            foreach (var dette in dettes) {
                if (dette.Montant == dette.MontantVerser) {
                    detteRepository.UpdateEtatDette(dette, Etat.ARCHIVER);
                }
            }
        }

        public Dette GetById(int id)
        {
            return detteRepository.SelectById(id);
        }

        public List<Dette> GetDettesByClient(List<Dette> dettes, Client client)
        {
            List<Dette> dettesClient = new List<Dette>();
            foreach (var dette in dettes) {
                if (dette.Client.Id == client.Id) {
                    dettesClient.Add(dette);
                }
            }
            return dettesClient;
        }

        public List<Dette> GetDettesByEtat(Etat etat)
        {
            return detteRepository.SelectDettesByEtat(etat);
        }

        public int Save(Dette entity)
        {
            return detteRepository.Insert(entity);
        }

        public List<Dette> Show()
        {
            return detteRepository.SelectAll();
        }

        public List<Dette> ShowDettesNoSoldeClient(Client client)
        {
            return detteRepository.SelectDettesNoSoldeClient(client);
        }

        public void UpdateDette(Dette dette)
        {
            detteRepository.UpdateDette(dette);
        }

        public void UpdateEtatDette(Dette dette, Etat etat)
        {
            detteRepository.UpdateEtatDette(dette, etat);
        }
    }
}