using System;
using System.Threading.Tasks;
using ContaCorrente.Extrato.Aplicacao.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace ContaCorrente.Extrato.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtratoController : ControllerBase
    {
        private readonly IConsultaDeExtrato _consultaDeExtrato;

        public ExtratoController(IConsultaDeExtrato consultaDeExtrato)
        {
            _consultaDeExtrato = consultaDeExtrato;
        }

        [HttpGet("{idCliente}")]
        public async Task<ActionResult> Get(Guid idCliente)
        {
            try
            {
                 var extrato = await _consultaDeExtrato.Obter(idCliente);
                 if (extrato == null)
                     return NotFound();
                 return new JsonResult(extrato);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
