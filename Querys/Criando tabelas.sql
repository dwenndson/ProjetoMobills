CREATE DATABASE ApiProjectMobillis
GO

USE ApiProjectMobillis
GO

CREATE TABLE tbl_Despesa
(
	Id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
	Descricao NVARCHAR(50) not null,
	Valor DECIMAL(18, 2) not null,
	Data DateTime not null,
	Pago BIT not null
)

CREATE TABLE tbl_Receita
(
	Id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
	Descricao NVARCHAR(50) not null,
	Valor DECIMAL(18, 2) not null,
	Data DateTime not null,
	Recebido BIT not null
)

