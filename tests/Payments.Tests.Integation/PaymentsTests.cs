using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Payments.API;
using Xunit;

namespace Payments.Tests.Integation
{
    public class PaymentsTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public PaymentsTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task ReturnPayment()
        {
            var response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal("Hello World!", responseString);
        }
    }
}