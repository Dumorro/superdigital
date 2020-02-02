using ContaCorrente.Lacamentos.Aplicacao.Dtos;
using System.Threading.Tasks;

namespace ContaCorrente.Lacamentos.Aplicacao.Servicos
{
    public interface IEnvioDeLacamentoEmContacorrente
    {
        Task Enviar(LancamentoDto lancamento);
    }
}
