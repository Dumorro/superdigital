using ContaCorrente.Lacamentos.Aplicacao.Dtos;
using ContaCorrente.Lacamentos.Aplicacao.Servicos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ContaCorrente.Lacamentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LacamentosController : ControllerBase
    {
        public readonly IEnvioDeLacamentoEmContacorrente _envioDeLacamento;
        public LacamentosController(IEnvioDeLacamentoEmContacorrente envioDeLacamento)
        {
            _envioDeLacamento = envioDeLacamento;
        }

        [HttpPost]
        public async Task Post([FromBody] LancamentoDto lancamento)
        {
            await _envioDeLacamento.Enviar(lancamento);
        }
    }
}
