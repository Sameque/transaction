using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Transactions.Teste
{
    public class BankTeste  
    {
        
        private IHttpClientFactory _httpClientFactory;
        public HttpClient Client { get; private set; }
        [Fact]
        public async Task List()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = server.CreateClient();

            var response = await Client.GetAsync("/banks");
            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
        }

        [Fact]
        public async Task Get()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = server.CreateClient();

            var response = await Client.GetAsync("/bank/1");
            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
        }
    }
}