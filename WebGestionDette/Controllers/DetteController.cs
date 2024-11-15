using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebGestionDette.Data;
using WebGestionDette.Models;
using WebGestionDette.Models.Enum;
using WebGestionDette.Service;

namespace WebGestionDette.Controllers
{
    public class DetteController : Controller
    {
        private readonly WebGesDetteContext _context;
        private readonly IDetteService _detteService;
        private readonly IClientService _clientService;

        public DetteController(IDetteService detteService, IClientService clientService)
        {
            _detteService = detteService;
            _clientService = clientService;
        }

        // GET: Dette
        public async Task<IActionResult> Index(string etat, string surname,int pageNumber = 1, int limit = 4)
        {
            var client = await _clientService.SelectBySurname(surname);
            IEnumerable<Dette> dettes;
            int totalDettes;
            int maxPages;
            if (!string.IsNullOrEmpty(surname) && client != null){
                dettes = await _detteService.SelectByClient(client.Id);
                totalDettes = _detteService.SelectByClient(client.Id).Result.Count();
            }
            else if (!string.IsNullOrEmpty(etat)) {
                switch (etat) {
                    case "solde":
                        dettes = await _detteService.SelectDetteSolde(pageNumber, limit);
                        totalDettes = _detteService.SelectDetteSolde().Result.Count();
                        break;
                    case "nonSolde":
                        dettes = await _detteService.SelectDetteNonSolde(pageNumber, limit);
                        totalDettes = _detteService.SelectDetteNonSolde().Result.Count();
                        break;
                    default:
                        dettes = await _detteService.SelectDetteAsync(pageNumber, limit);
                        totalDettes = _detteService.SelectDetteAsync().Result.Count();
                        break;
                }
            }
            else
            {
                dettes = await _detteService.SelectDetteAsync(pageNumber, limit);
                totalDettes =  _detteService.SelectDetteAsync().Result.Count();
            }
            maxPages = (int)Math.Ceiling((double)totalDettes / limit);
            
            ViewBag.CurrentPage = pageNumber;
            ViewBag.MaxPages = maxPages;
            ViewBag.Etat = etat;
            return View(dettes);
        }
    

        // GET: Dette/Create
        public IActionResult Create()
        {
            ViewBag.clientId = new SelectList(_clientService.SelectClientsAsync().Result, "Id", "Surname");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Dette dette)
        {
            ModelState.Remove("Details");
            ModelState.Remove("Payements");
            ModelState.Remove("Client");
            dette.MontantVerser = 0;
            if (ModelState.IsValid)
            {
                await _detteService.Insert(dette);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.clientId = new SelectList(_clientService.SelectClientsAsync().Result, "Id", "Surname", dette.clientId);
            return View(dette);
        }


        public async Task<IActionResult> Delete(int detteId)
        {
            await _detteService.Delete(detteId);
            return RedirectToAction("Index");
        }

    }
}
