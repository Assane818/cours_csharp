using WebGestionDette.Core;
using WebGestionDette.Models;
using WebGestionDette.Models.Enum;

namespace WebGestionDette.Service;

public interface IDetteService : IService<Dette>
{
    Task<IEnumerable<Dette>> SelectByClient(int clientId);
    Task<IEnumerable<Dette>> SelectByClient(int clientId, int pageNumber, int limit);
    Task<IEnumerable<Dette>> SelectDetteAsync();
    Task<IEnumerable<Dette>> SelectDetteAsync(int pageNumber, int limit);
    Task<IEnumerable<Dette>> SelectDetteSolde();
    Task<IEnumerable<Dette>> SelectDetteSolde(int pageNumber, int limit);
    Task<IEnumerable<Dette>> SelectDetteNonSolde();
    Task<IEnumerable<Dette>> SelectDetteNonSolde(int pageNumber, int limit);
    Task Delete(int id);
}