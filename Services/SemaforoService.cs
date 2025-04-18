using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrafficManagementSystem
{
    public interface ISemaforoService
    {
        Task<PaginatedResult<Semaforo>> ObterSemaforosComPaginaAsync(int page, int pageSize);
        Task<Semaforo> AjustarSemaforoAsync(AjusteSemaforoDto dto);
        Task<List<PadrãoDeTrafego>> ObterPadroesDeTrafegoAsync();
    }

    public class SemaforoService : ISemaforoService
    {
        private readonly ApplicationDbContext _context;

        public SemaforoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedResult<Semaforo>> ObterSemaforosComPaginaAsync(int page, int pageSize)
        {
            var query = _context.Semaforos.AsQueryable();
            var totalCount = await query.CountAsync();
            var semaforos = await query.Skip((page - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();

            return new PaginatedResult<Semaforo>
            {
                TotalCount = totalCount,
                PageSize = pageSize,
                CurrentPage = page,
                Items = semaforos
            };
        }

        public async Task<Semaforo> AjustarSemaforoAsync(AjusteSemaforoDto dto)
        {
            var semaforo = await _context.Semaforos.FindAsync(dto.SemaforoId);
            if (semaforo == null)
            {
                throw new Exception("Semáforo não encontrado");
            }
            semaforo.Duracao = CalcularDuracao(semaforo, dto.FlujoDeTrafego, dto.CondicoesClimaticas);
            _context.Update(semaforo);
            await _context.SaveChangesAsync();
            return semaforo;
        }

        public async Task<List<PadrãoDeTrafego>> ObterPadroesDeTrafegoAsync()
        {
            var padroes = new List<PadrãoDeTrafego>
            {
                new PadrãoDeTrafego { Id = 1, Nome = "Tráfego leve", Descrição = "Tráfego sem congestionamento" },
                new PadrãoDeTrafego { Id = 2, Nome = "Tráfego moderado", Descrição = "Alguns congestionamentos em pontos específicos" },
                new PadrãoDeTrafego { Id = 3, Nome = "Tráfego pesado", Descrição = "Congestionamento generalizado nas principais vias" }
            };

            return await Task.FromResult(padroes);
        }
    }
}
