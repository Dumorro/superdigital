using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ContaCorrente.Extrato.Dominio.Adaptadores;
using ContaCorrente.Extrato.Dominio.Entidades;
using Dapper;

namespace ContaCorrente.Extrato.Infra.ExtratoRepositorio
{
    public class ExtratoRepositorio : IExtratoRepositorio
    {
        private readonly IDbConnection _dbConnection;

        public ExtratoRepositorio(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Lancamento>> ListarLancamentos(Guid idCliente)
        {
            Console.WriteLine($"Consulta em banco para o cliente {idCliente}");

            var query = @"SELECT IdCliente, ContaOrigem, ContaDestino, Data, Tipo, Descricao, Valor 
                           FROM Lancamentos (nolock) 
                           WHERE IdCliente = @idCliente";
            var parametros = new DynamicParameters();
            parametros.Add("idCliente", idCliente, DbType.Guid);

            var lancamentos = await _dbConnection.QueryAsync<Lancamento>(query, parametros);

            return lancamentos;
        }
    }
}
