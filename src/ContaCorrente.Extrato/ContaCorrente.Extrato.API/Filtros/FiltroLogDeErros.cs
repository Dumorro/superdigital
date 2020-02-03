using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace ContaCorrente.Extrato.API.Filtros
{
    public class FiltroLogDeErros : IExceptionFilter
    {
        public readonly ILogger _logger;

        public FiltroLogDeErros(ILogger<FiltroLogDeErros> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception.Message);
        }
    }
}
