using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrafficManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemaforoController : ControllerBase
    {
        private readonly ISemaforoService _semaforoService;
        public SemaforoController(ISemaforoService semaforoService)
        {
            _semaforoService = semaforoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSemaforos([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var semaforos = await _semaforoService.ObterSemaforosComPaginaAsync(page, pageSize);
                return Ok(semaforos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter semáforos: {ex.Message}");
            }
        }

        [HttpPost("ajustar")]
        [Authorize]
        public async Task<IActionResult> AjustarSemaforo([FromBody] AjusteSemaforoDto dto)
        {
            try
            {
                var semaforo = await _semaforoService.AjustarSemaforoAsync(dto);
                return Ok(semaforo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao ajustar semáforo: {ex.Message}");
            }
        }

        [HttpPost("detectar-acidente")]
        [Authorize]
        public async Task<IActionResult> DetectarAcidente([FromBody] DetecçãoAcidenteDto dto)
        {
            try
            {
                var acidente = await _acidenteService.DetectarAcidenteAsync(dto);
                return Ok(acidente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao detectar acidente: {ex.Message}");
            }
        }

        [HttpGet("trafego/padroes")]
        public async Task<IActionResult> GetPadroesDeTrafego()
        {
            try
            {
                var padroes = await _semaforoService.ObterPadroesDeTrafegoAsync();
                return Ok(padroes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter padrões de tráfego: {ex.Message}");
            }
        }
    }
}
