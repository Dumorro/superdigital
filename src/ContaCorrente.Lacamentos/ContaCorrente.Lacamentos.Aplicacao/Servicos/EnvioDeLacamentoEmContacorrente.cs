using System;
using ContaCorrente.Lacamentos.Aplicacao.Dtos;
using System.Threading.Tasks;
using ContaCorrente.Lacamentos.Dominio.Entidades;
using MassTransit;

namespace ContaCorrente.Lacamentos.Aplicacao.Servicos
{
    public class EnvioDeLacamentoEmContacorrente : IEnvioDeLacamentoEmContacorrente
    {
        private readonly Uri _endpointUri;
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public EnvioDeLacamentoEmContacorrente(ISendEndpointProvider sendEndpointProvider, 
            DadosDeConfiguracaoDoServicoDeMensageria dadosDeConfiguracao)
        {
            _sendEndpointProvider = sendEndpointProvider;
            _endpointUri = new Uri(dadosDeConfiguracao.EnderecoDaFila);
        }

        public async Task Enviar(LancamentoDto lancamentoDto)
        {
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(_endpointUri);
            var lancamento = MapeadorDeLancamento.Mapear(lancamentoDto);
            await endpoint.Send(lancamento);
        }
    }
}
