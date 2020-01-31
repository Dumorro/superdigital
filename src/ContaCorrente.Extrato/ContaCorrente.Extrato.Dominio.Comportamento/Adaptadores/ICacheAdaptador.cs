using System;
using System.Collections.Generic;
using System.Text;
using ContaCorrente.Extrato.Dominio.Entidades;

namespace ContaCorrente.Extrato.Dominio.Comportamento.Adaptadores
{
    public interface ICacheAdaptador
    {
        ExtratoDaContaCorrenteEmCache Obter(string chave);
        void Adicionar(string chave, IEnumerable<Lacamento> lacamentos);
    }
}
