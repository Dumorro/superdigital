namespace ContaCorrente.Lacamentos.Dominio.Entidades
{
    public class DadosDeConfiguracaoDoServicoDeMensageria
    {
        public string Conexao { get; private set; }
        public string EnderecoDaFila { get; private set; }

        public DadosDeConfiguracaoDoServicoDeMensageria(string conexao, string enderecoDaFila)
        {
            Conexao = conexao;
            EnderecoDaFila = enderecoDaFila;
        }
    }
}
