using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace ContaCorrente.Lacamentos.TestesDeIntegracao.Contexto
{
    public class ContextoDeTeste
    {
        public HttpClient Client { get; set; }
        private readonly TestServer _testServer;

        public ContextoDeTeste()
        {
            _testServer = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseConfiguration(new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build()
                ).UseStartup<Startup>());
            Client = _testServer.CreateClient();
        }
    }
}
