using ContaCorrente.Extrato.TestesDeIntegracao.Contexto;
using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ContaCorrente.Extrato.TestesDeIntegracao
{
    public class ExtratoControllerTeste
    {
        private readonly ContextoDeTeste _contextoDeTeste = new ContextoDeTeste();

        [Fact]
        public async Task DeveRetornarExtratoDoCliente()
        {
            const string idCliente = "0796af9c-3347-4d7b-8607-a30d8bfd327c";
            var recurso = $"/api/extrato/{idCliente}";
            var resultado = await _contextoDeTeste.Client.GetAsync(recurso);

            resultado.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
