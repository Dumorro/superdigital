using ContaCorrente.Lacamentos.Aplicacao.Dtos;
using ContaCorrente.Lacamentos.TestesDeIntegracao.Contexto;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContaCorrente.Lacamentos.TestesDeIntegracao
{
    public class LacamentoControllerTestes
    {
        private readonly ContextoDeTeste _contextoDeTeste = new ContextoDeTeste();

        [Fact]
        public async Task DeveEnviarLacamentoParaContaCorrente()
        {
            const string recurso = "/api/lacamentos";
            var lancamento = new LancamentoDto()
            {
                IdCliente = Guid.NewGuid(),
                ContaDestino = "050058454",
                ContaOrigem = "050050527",
                Data = DateTime.Now,
                Tipo = 1,
                Valor = 550.00
            };
            var conteudo = new StringContent(JsonConvert.SerializeObject(lancamento), Encoding.UTF8, "application/json");
            var resultado = await _contextoDeTeste.Client.PostAsync(recurso, conteudo);

            resultado.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
