using Microsoft.AspNetCore.Mvc;
using WebGestionDette.Models;
using WebGestionDette.Service;

namespace WebGestionDette.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        public async Task<IActionResult> Index()
        {
            var clients = await _clientService.SelectClientsAsync();
            return View(clients);
        }

        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Form(Client client, bool toggleSwitch)
        {
            if (!toggleSwitch)
            {
                ModelState.Remove("User.Nom");
                ModelState.Remove("User.Prenom");
                ModelState.Remove("User.Login");
                ModelState.Remove("User.Password");
                client.User = null;
            }
            if (ModelState.IsValid)
            {
                await _clientService.Insert(client);
                return RedirectToAction("Index");
            }
            return View(client);
        }

        public IActionResult Supprime(int clientId)
        {
            _clientService.Delete(clientId);
            return RedirectToAction("Index");
        }
    }
}