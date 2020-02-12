using ContaCorrente.Extrato.Processadores.Dominio.Adaptadores;
using ContaCorrente.Extrato.Processadores.Dominio.Entidade;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Transactions;

namespace ContaCorrente.Extrato.Processadores.Infra.ExtratoRepositorio
{
    public class ExtratoRepositorio : IExtratoRepositorio
    {
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<ExtratoRepositorio> _logger;
        public ExtratoRepositorio(ILogger<ExtratoRepositorio> logger, IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            _logger = logger;
        }

        public void SalvarLancamento(Lancamento lancamento)
        {
            try
            {
                using (var ts = new TransactionScope())
                {

                    var sql = @"INSERT [dbo].[Lancamentos] ([IdCliente], [ContaOrigem], [ContaDestino], [Data], [Tipo], [Descricao], [Valor])
                        VALUES (@idCliente, @contaOrigem, @contaDestino, @data, @tipo, @descricao, @valor)";
                    var parametros = new DynamicParameters();
                    parametros.Add("@idCliente", lancamento.IdCliente, DbType.Guid);
                    parametros.Add("@contaOrigem", lancamento.ContaOrigem, DbType.String);
                    parametros.Add("@contaDestino", lancamento.ContaDestino, DbType.String);
                    parametros.Add("@data", lancamento.Data, DbType.DateTime);
                    parametros.Add("@tipo", lancamento.Tipo, DbType.Int16);
                    parametros.Add("@descricao", lancamento.Descricao, DbType.String);
                    parametros.Add("@valor", lancamento.Valor, DbType.Double);

                    _dbConnection.Execute(sql, parametros);

                    ts.Complete();

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }
    }
}
