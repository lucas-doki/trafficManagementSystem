using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace TrafficManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcidenteController : ControllerBase
    {
        private readonly IAcidenteService _acidenteService;

        public AcidenteController(IAcidenteService acidenteService)
        {
            _acidenteService = acidenteService;
        }

        [HttpPost("detectar")]
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
    }
}
