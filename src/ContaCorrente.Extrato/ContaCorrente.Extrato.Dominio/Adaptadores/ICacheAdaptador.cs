using System.Threading.Tasks;
using ContaCorrente.Extrato.Dominio.Entidades;

namespace ContaCorrente.Extrato.Dominio.Adaptadores
{
    public interface ICacheAdaptador
    {
        Task<ExtratoDaContaCorrenteEmCache> Obter(string chave);
        Task Adicionar(string chave, ExtratoDaContaCorrenteEmCache extrato);
    }
}
