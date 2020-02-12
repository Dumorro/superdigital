using ContaCorrente.Extrato.Processadores.Dominio.Entidade;

namespace ContaCorrente.Extrato.Processadores.Dominio.Adaptadores
{
    public interface IExtratoRepositorio
    {
        void SalvarLancamento(Lancamento lancamento);
    }
}
