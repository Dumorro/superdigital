using ContaCorrente.Extrato.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace ContaCorrente.Extrato.TestesDeIntegracao.Contexto
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

