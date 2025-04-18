using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TrafficManagementSystem.Tests
{
    public class SemaforoControllerTests
    {
        private readonly SemaforoController _controller;
        private readonly Mock<ISemaforoService> _semaforoServiceMock = new Mock<ISemaforoService>();

        public SemaforoControllerTests()
        {
            _controller = new SemaforoController(_semaforoServiceMock.Object);
        }

        [Fact]
        public async Task AjustarSemaforo_ReturnsOkStatusCode()
        {
            var dto = new AjusteSemaforoDto { SemaforoId = 1, FlujoDeTrafego = 50, CondicoesClimaticas = "Boa" };
            _semaforoServiceMock.Setup(s => s.AjustarSemaforoAsync(dto)).ReturnsAsync(new Semaforo());

            var result = await _controller.AjustarSemaforo(dto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
