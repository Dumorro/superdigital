### Solução proposta

A solução é dividida em 3 projetos, 2 API's e um Service Worker.
- API de consulta do Extrato. ***ContaCorrente.Extrato***
- API para envio dos Lançamentos da Conta para para a fila de mensageria para processamento com consistência eventual. ***ContaCorrente.Lacamentos***
- Service Worker para processamento das mensagens e atualização do DB. ***ContaCorrente.Extrato.Processadores***

A proposta é apresentar uma estrura com implementação simples, afim de passar de maneira mais abrangente pelos pontos solicitados no teste. (DDD, SOLID, Testes de Unidade e Integração).

Padrões arquiteturais como Correlação de Mensagens, EventSourcing,  Circuit Breaker, tratamento e manipulação de exceções, entre outros, foram abstraídos afim de manter a mínima implementação necessária.

Testes de Unidade e Integração estão demonstrados nos projetos:
* /src/ContaCorrente.Extrato/ContaCorrente.Extrato.TestesDeIntegracao/
* /src/ContaCorrente.Extrato/ContaCorrente.Extrato.TestesDeUnidade/

![](https://raw.githubusercontent.com/Dumorro/imgs/master/modelo-arq.png)


### Configuração
* Criar uma base no SQL Server
* Executar o script de criação da tabela de Lacamentos: ***src/ContaCorrente.Extrato/TabelaLancamento.sql***
* Alterar as strings de conexão dos arquivos de configuração dos projetos:  **ContaCorrente.Extrato.API** e **ContaCorrente.Extrato.Processadores**:
-*/src/ContaCorrente.Extrato/ContaCorrente.Extrato.API/appsettings.json*
-*/src/ContaCorrente.Extrato.Processadores/ContaCorrente.Extrato.Processadores/appsettings.json*

As soluções possuem um Dockerfile na raiz do projeto API ou no Worker.
