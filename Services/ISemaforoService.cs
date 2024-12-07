using System.Threading.Tasks;
using TrafficManagementSystem.Models;

namespace TrafficManagementSystem.Services
{
    public interface ISemaforoService
    {
        Task<PaginatedResult<Semaforo>> ObterSemaforosComPaginaAsync(int page, int pageSize);
        Task<Semaforo> AjustarSemaforoAsync(AjusteSemaforoDto dto);
    }
}
