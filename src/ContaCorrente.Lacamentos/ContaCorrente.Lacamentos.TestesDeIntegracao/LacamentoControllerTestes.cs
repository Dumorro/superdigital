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
                Valor = DateTime.Now.Minute+500
            };
            var conteudo = new StringContent(JsonConvert.SerializeObject(lancamento), Encoding.UTF8, "application/json");
            var resultado = await _contextoDeTeste.Client.PostAsync(recurso, conteudo);
            var lancamento2 = new LancamentoDto()
            {
                IdCliente = Guid.NewGuid(),
                ContaDestino = "050058454",
                ContaOrigem = "050050527",
                Data = DateTime.Now,
                Tipo = 1,
                Valor = DateTime.Now.Minute + 500
            };
            var conteudo2 = new StringContent(JsonConvert.SerializeObject(lancamento2), Encoding.UTF8, "application/json");
            var resultado2 = await _contextoDeTeste.Client.PostAsync(recurso, conteudo2);


            resultado.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
