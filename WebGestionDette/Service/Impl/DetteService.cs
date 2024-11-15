using Microsoft.EntityFrameworkCore;
using WebGestionDette.Data;
using WebGestionDette.Models;
using WebGestionDette.Models.Enum;

namespace WebGestionDette.Service.Impl;
public class DetteService : IDetteService
{
    private readonly WebGesDetteContext _context;
    public DetteService(WebGesDetteContext context)
    {
        _context = context;
    }

    public async Task Delete(int id)
    {
        _context.Remove(await SelectById(id)!);
        await _context.SaveChangesAsync();
    }

    public async Task<int> Insert(Dette entity)
    {
        _context.Dettes.Add(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Dette>> SelectByClient(int clientId, int pageNumber, int limit)
    {
        return await _context.Dettes.Where(d => d.clientId == clientId)
            .Skip((pageNumber - 1) * limit)
            .Take(limit)
            .ToListAsync();
    }

    public async Task<IEnumerable<Dette>> SelectByClient(int clientId)
    {
        return await _context.Dettes.Where(d => d.clientId == clientId).ToListAsync();
    }


    public async Task<Dette?> SelectById(int id)
    {
        return await _context.Dettes.FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<IEnumerable<Dette>> SelectDetteAsync()
    {
        return await _context.Dettes.Include(d => d.Client).ToListAsync();
    }

    public async Task<IEnumerable<Dette>> SelectDetteAsync(int pageNumber, int limit)
    {
        return await _context.Dettes
            .Include(d => d.Client)
            .Skip((pageNumber - 1) * limit)
            .Take(limit)
            .ToListAsync();
    }

    public async Task<IEnumerable<Dette>> SelectDetteNonSolde()
    {
        return await _context.Dettes.Where(d => d.Montant!= d.MontantVerser).ToListAsync();
    }

    public async Task<IEnumerable<Dette>> SelectDetteNonSolde(int pageNumber, int limit)
    {
        return await _context.Dettes.Where(d => d.Montant != d.MontantVerser)
            .Skip((pageNumber - 1) * limit)
            .Take(limit)
            .ToListAsync();
    }

    public async Task<IEnumerable<Dette>> SelectDetteSolde()
    {
        return await _context.Dettes.Where(d => d.Montant == d.MontantVerser).ToListAsync();
    }

    public async Task<IEnumerable<Dette>> SelectDetteSolde(int pageNumber, int limit)
    {
        return await _context.Dettes.Where(d => d.Montant == d.MontantVerser)
            .Skip((pageNumber - 1) * limit)
            .Take(limit)
            .ToListAsync();
    }
}