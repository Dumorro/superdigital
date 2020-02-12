namespace ContaCorrente.Extrato.Processadores.Dominio.Models
{
    public class DadosDeConfigacaoDaMensageria
    {
        public string Conexao { get; private set; }
        public string NomeDaFila{ get; private set; }
 
        public DadosDeConfigacaoDaMensageria(string conexao, string nomeDaFila)
        {
            Conexao = conexao;
            NomeDaFila = nomeDaFila;
        }
    }
}
