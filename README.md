#### Proposta arquitetural

![](https://raw.githubusercontent.com/Dumorro/imgs/master/modelo-arq.png)


### Configuração
* Criar uma BD SQL Server
* Executar o script de criação da tabela de Lacamentos: ***src/ContaCorrente.Extrato/TabelaLancamento.sql***
* Alterar as strings de conexão dos arquivos de configuração dos projetos 
   **ContaCorrente.Extrato.API** e  **ContaCorrente.Extrato.Processadores**: 
   --*src/ContaCorrente.Extrato/ContaCorrente.Extrato.API/appsettings.json*
   --*src/ContaCorrente.Extrato.Processadores/ContaCorrente.Extrato.Processadores/appsettings.json*
