using ContaCorrente.Lacamentos.Aplicacao.Dtos;
using ContaCorrente.Lacamentos.Dominio.Adaptadores;
using System.Threading.Tasks;

namespace ContaCorrente.Lacamentos.Aplicacao.Servicos
{
    public class EnvioDeLacamentoEmContacorrente : IEnvioDeLacamentoEmContacorrente
    {
        private readonly IMensageriaAdaptador _mensageria;
        
        public EnvioDeLacamentoEmContacorrente(IMensageriaAdaptador mensageria)
        {
            _mensageria = mensageria;
        }

        public async Task Enviar(LancamentoDto lancamentoDto)
        {
            var lancamento = MapeadorDeLancamento.Mapear(lancamentoDto);
            await _mensageria.EnviarMensagem(lancamento);
        }
    }
}
