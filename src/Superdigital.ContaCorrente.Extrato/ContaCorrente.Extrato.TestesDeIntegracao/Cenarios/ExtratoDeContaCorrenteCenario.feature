#language: pt-BR

Funcionalidade: Dado que ou um cliente Superdital
	Gostaria de consultar meu extrato da conta corrente

Cenário: Obter o extrato da conta corrente do cliente
	Dado que a url da API é  'http://localhost:5000/api/extrato/0796af9c-3347-4d7b-8607-a30d8bfd327c'
	Quando chamar o serviço
	Entao o StatusCode da resposta dever ser 200
