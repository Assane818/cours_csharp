using Microsoft.AspNetCore.Mvc;
using WebGestionDette.Entities;
using WebGestionDette.Models;

namespace WebGestionDette.Controllers
{
    public class ClientController : Controller
    {
        private IClientModel clientModel;
        
        public ClientController(IClientModel clientModel)
        {
            this.clientModel = clientModel;
        }
        public IActionResult Index()
        {
            var clients = clientModel.SelectAll();
            return View(clients);
        }
        
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form(Client client, bool toggleSwitch)
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
                clientModel.Insert(client);
                return RedirectToAction("Index");
            }
            return View(client);
        }

        public IActionResult Supprime(int clientId) {
            clientModel.Delete(clientId);
            return RedirectToAction("Index");
        }
    }
}