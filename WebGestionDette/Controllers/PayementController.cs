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

namespace WebGestionDette.Controllers
{
    public class PayementController : Controller
    {
        private readonly WebGesDetteContext _context;

        public PayementController(WebGesDetteContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var webGesDetteContext = _context.Payements.Include(p => p.Dette);
            return View(await webGesDetteContext.ToListAsync());
        }

        public async Task<IActionResult> PayementDette(int detteId)
        {
            ViewBag.DetteId = detteId;
            var webGesDetteContext = _context.Payements.Include(p => p.Dette).Where(p => p.detteId == detteId);
            return View(await webGesDetteContext.ToListAsync());
        }

        
        public IActionResult Create(int detteId)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int detteId, Payement payement)
        {
            ModelState.Remove("Dette");
            if (ModelState.IsValid)
            {
                _context.Add(payement);
                await _context.SaveChangesAsync();
                var dette = await _context.Dettes.FirstOrDefaultAsync(d => d.Id == detteId);
                dette.MontantVerser += payement.MontantPayer;
                if (dette.Montant == dette.MontantVerser)
                {
                    dette.Etat = Etat.ARCHIVER;
                }
                _context.Dettes.Update(dette);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(PayementDette), new { detteId = detteId });
            }
            ViewData["detteId"] = new SelectList(_context.Dettes, "Id", "Id", payement.detteId);
            return View(payement);
        }

        // GET: Payement/Delete/5
        public async Task<IActionResult> Delete(int payementId)
        {
            var payement = await _context.Payements
                .FirstOrDefaultAsync(p => p.Id == payementId);
            _context.Payements.Remove(payement!);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(PayementDette), new { detteId = payement.detteId });
        }
    }

}
