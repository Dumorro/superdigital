CREATE TABLE [dbo].[Lancamentos]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [IdCliente] UNIQUEIDENTIFIER NOT NULL, 
    [ContaOrigem] VARCHAR(10) NOT NULL, 
    [ContaDestino] VARCHAR(10) NOT NULL, 
    [Data] DATE NOT NULL, 
    [Tipo] SMALLINT NOT NULL, 
    [Descricao] VARCHAR(250) NOT NULL, 
    [Valor] DECIMAL(10, 2) NOT NULL
)
