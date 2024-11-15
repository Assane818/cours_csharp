using Microsoft.AspNetCore.Mvc;
using WebGestionDette.Models;
using WebGestionDette.Models.Enum;
using WebGestionDette.Service;


namespace WebGestionDette.Controllers
{
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientService _clientService;
        private readonly IDetteService _detteService;

        public ClientController(IClientService clientService, ILogger<ClientController> logger, IDetteService detteService)
        {
            _logger = logger;
            _clientService = clientService;
            _detteService = detteService;
        }

        public async Task<IActionResult> Index(int pageNumber = 1, int limit = 4)
        {
            var clients = await _clientService.SelectClientsAsync(pageNumber, limit);
            int totalClients = _clientService.SelectClientsAsync().Result.Count();
            int maxPages = (int)Math.Ceiling((double)totalClients / limit);

            ViewBag.CurrentPage = pageNumber;
            ViewBag.MaxPages = maxPages;
            return View(clients);
        }

        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Form(Client client, bool toggleSwitch)
        {
            ModelState.Remove("MontantVerser");
            ModelState.Remove("Details");
            ModelState.Remove("Payements");
                        
            if (!toggleSwitch)
            {
                ModelState.Remove("User.Nom");
                ModelState.Remove("User.Prenom");
                ModelState.Remove("User.Login");
                ModelState.Remove("User.Password");
                client.User = null;
            }
            else
            {
                client.User!.Role = Role.CLIENT;
            }
            if (ModelState.IsValid)
            {
                Console.WriteLine("Client enregistré");
                await _clientService.Insert(client);
                return RedirectToAction("Index");
            }
            return View(client);
        }

        public async Task<IActionResult> Supprime(int clientId)
        {
            await _clientService.Delete(clientId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ClientDette(int clientId, int pageNumber = 1, int limit = 4)
        {
            var dettes = await _detteService.SelectByClient(clientId,pageNumber, limit);
            int totalDettes = _detteService.SelectByClient(clientId).Result.Count();
            int maxPages = (int)Math.Ceiling((double)totalDettes / limit);
            ViewBag.CurrentPage = pageNumber;
            ViewBag.MaxPages = maxPages;
            ViewBag.ClientId = clientId;
            return View(dettes);
        }
    }
}
