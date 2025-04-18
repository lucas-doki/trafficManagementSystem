using System.Threading.Tasks;
using TrafficManagementSystem.Models;

namespace TrafficManagementSystem.Services
{
    public interface IAcidenteService
    {
        Task<Acidente> DetectarAcidenteAsync(DetecçãoAcidenteDto dto);
    }
}
