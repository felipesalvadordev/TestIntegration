using System.Net;
using FluentAssertions;
using System.Threading.Tasks;
using WebApp.TesteIntegracao.Fixtures;
using Xunit;

namespace WebApp.TesteIntegracao.Scenarios
{
    public class ValuesTest
    {
        private readonly TestContext _testContext;
        public ValuesTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task GetRetornaOk()
        {
            var response = await _testContext.Client.GetAsync("/api/values");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetByIDRetornaOK()
        {
            var response = await _testContext.Client.GetAsync("/api/values/5");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetByIdInvalidoRetornaBadRequest()
        {
            var response = await _testContext.Client.GetAsync("/api/values/XXX");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task GetByIdVerificaContentType()
        {
            var response = await _testContext.Client.GetAsync("/api/values/5");
            response.EnsureSuccessStatusCode();
            response.Content.Headers.ContentType.ToString().Should().Be("text/plain; charset=utf-8");
        }
    }
}
