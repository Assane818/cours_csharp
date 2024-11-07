using GesDette.Data.Entities;
using GesDette.Data.Service;

namespace GesDette.Views.Impl
{
    public class ClientViewImpl : ViewImpl<Client>, IClientView
    {
        private IClientService clientService;

        public ClientViewImpl(IClientService clientService) {
            this.clientService = clientService;
        }

        public override Client Saisie()
        {
            Client client = new();
            do {
                Console.WriteLine("Saisir le surname de l'utilisateur");
                client.Surname = Console.ReadLine();
            } while (clientService.GetBySurname(client.Surname) != null);
            do {
                Console.WriteLine("Saisir le numero de telephone de l'utilisateur");
                client.Phone = Console.ReadLine();
            } while (clientService.GetByPhone(client.Phone) != null);
            Console.WriteLine("Saisir l'adresse de l'utilisateur");
            client.Address = Console.ReadLine();
            return client;
        }
    }
}