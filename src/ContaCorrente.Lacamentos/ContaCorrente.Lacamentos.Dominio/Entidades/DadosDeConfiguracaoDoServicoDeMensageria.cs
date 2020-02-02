using System;
using System.Collections.Generic;
using System.Text;

namespace ContaCorrente.Lacamentos.Dominio.Entidades
{
    public class DadosDeConfiguracaoDoServicoDeMensageria
    {
        public string Conexao { get; private set; }
        public string NomeDaFila { get; private set; }

        public DadosDeConfiguracaoDoServicoDeMensageria(string conexao, string nomeDaFila)
        {
            Conexao = conexao;
            NomeDaFila = nomeDaFila;
        }
    }
}
