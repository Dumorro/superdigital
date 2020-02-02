using ContaCorrente.Extrato.Processadores.Dominio.Adaptadores;
using ContaCorrente.Extrato.Processadores.Dominio.Entidade;
using Dapper;

namespace ContaCorrente.Extrato.Processadores.Infra.ExtratoRepositorio
{
    public class ExtratoRepositorio : IExtratoRepositorio
    {
        private readonly IDbConnection _dbConnection;
        public ExtratoRepositorio(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task SalvarLancamento(Lancamento lancamento)
        {
            var sql = @"INSERT [dbo].[Lancamentos] ([IdCliente], [ContaOrigem], [ContaDestino], [Data], [Tipo], [Descricao],[Valor])
                        VALUES (@idCliente, @contaOrigem, @contaDestino, @data, @tipo, @descricao, @valor)";
            var parametros = new DynamicParameters();
            parametros.Add("@idCliente", lancamento.IdCliente, DbType.Guid);
            parametros.Add("@contaOrigem", lancamento.ContaOrigem, DbType.String);
            parametros.Add("@contaDestino", lancamento.ContaDestino, DbType.String);
            parametros.Add("@data", lancamento.Data, DbType.DateTime);
            parametros.Add("@tipo", lancamento.Tipo, DbType.Int16);
            parametros.Add("@descricao", lancamento.IdCliente, DbType.String);
            parametros.Add("@valor", lancamento.IdCliente, DbType.Double);

            var linhasAfetadas = _dbConnection.Execute(sql, parametros);
        }
    }
}
