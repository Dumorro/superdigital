using System;
using System.Collections.Generic;
using System.Text;

namespace ContaCorrente.Extrato.Processadores.Dominio.Entidade
{
    public abstract class Mensagem
    {
        public DateTime DataCriacao => DateTime.Now;
    }
}
