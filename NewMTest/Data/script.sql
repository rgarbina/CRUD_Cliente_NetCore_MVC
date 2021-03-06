USE [master]
GO

CREATE DATABASE [NewM_Pessoa]
GO

USE [NewM_Pessoa]
GO

CREATE TABLE [dbo].[Pessoas](
	[PessoaId] [bigint] IDENTITY(1,1) NOT NULL,
	[DataInclusao] [date] NOT NULL,
	[DataEdicao] [datetime2](7) NOT NULL,
	[Ativado] [bit] NOT NULL,
	[Nome] [nvarchar](max) NOT NULL,
	[DataNascimento] [datetime2](7) NOT NULL,
	[Endereco] [nvarchar](max) NOT NULL,
	[Observacao] [nvarchar](300) NULL,
	[Celular] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Cpf] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Pessoas] PRIMARY KEY CLUSTERED 
(
	[PessoaId] ASC
)) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

INSERT [dbo].[Pessoas] ( [DataInclusao], [DataEdicao], [Ativado], [Nome], [DataNascimento], [Endereco], 
[Observacao], [Celular], [Email], [Cpf]) 
VALUES (CAST(N'2020-02-19' AS Date), CAST(N'2020-02-19T02:13:01.8496852' AS DateTime2), 
1, N'Raphael dos Santos Garbina', CAST(N'1994-05-03T00:00:00.0000000' AS DateTime2), 
N'rua matias de albuquerque 1371 jardim maria lucia', N'Desenvolvedor', N'17981515290', N'raphael@hotmail.com', N'70258976047')
GO

INSERT [dbo].[Pessoas] ( [DataInclusao], [DataEdicao], [Ativado], [Nome], [DataNascimento], [Endereco], 
[Observacao], [Celular], [Email], [Cpf]) 
VALUES (CAST(N'2020-02-19' AS Date), CAST(N'2020-02-19T02:13:01.8496852' AS DateTime2), 
1, N'Alice Aliciana', CAST(N'1999-05-03T00:00:00.0000000' AS DateTime2), 
N'rua matias de albuquerque 1371 jardim maria lucia', N'Desenvolvedora', N'17981515290', N'alice@hotmail.com', N'098.160.710-10')
GO

INSERT [dbo].[Pessoas] ( [DataInclusao], [DataEdicao], [Ativado], [Nome], [DataNascimento], [Endereco], 
[Observacao], [Celular], [Email], [Cpf]) 
VALUES (CAST(N'2020-02-19' AS Date), CAST(N'2020-02-19T02:13:01.8496852' AS DateTime2), 
1, N'Amanda Amadina', CAST(N'2000-05-03T00:00:00.0000000' AS DateTime2), 
N'rua matias de albuquerque 1371 jardim maria lucia', N'Executiva', N'17981515290', N'amandina@hotmail.com', N'896.765.460-03')
GO

INSERT [dbo].[Pessoas] ( [DataInclusao], [DataEdicao], [Ativado], [Nome], [DataNascimento], [Endereco], 
[Observacao], [Celular], [Email], [Cpf]) 
VALUES (CAST(N'2020-02-19' AS Date), CAST(N'2020-02-19T02:13:01.8496852' AS DateTime2), 
1, N'Achilles', CAST(N'1990-05-03T00:00:00.0000000' AS DateTime2), 
N'rua matias de albuquerque 1371 jardim maria lucia', N'Soldado', N'17981515290', N'troia@hotmail.com', N'05743319057')
GO

INSERT [dbo].[Pessoas] ( [DataInclusao], [DataEdicao], [Ativado], [Nome], [DataNascimento], [Endereco], 
[Observacao], [Celular], [Email], [Cpf]) 
VALUES (CAST(N'2020-02-19' AS Date), CAST(N'2020-02-19T02:13:01.8496852' AS DateTime2), 
1, N'Agnes ', CAST(N'1980-05-03T00:00:00.0000000' AS DateTime2), 
N'rua matias de albuquerque 1371 jardim maria lucia', N'Caçadora', N'17981515290', N'Agnes@hotmail.com', N'44069219072')
GO

INSERT [dbo].[Pessoas] ( [DataInclusao], [DataEdicao], [Ativado], [Nome], [DataNascimento], [Endereco], 
[Observacao], [Celular], [Email], [Cpf]) 
VALUES (CAST(N'2020-02-19' AS Date), CAST(N'2020-02-19T02:13:01.8496852' AS DateTime2), 
1, N'Atreus', CAST(N'1920-05-03T00:00:00.0000000' AS DateTime2), 
N'rua matias de albuquerque 1371 jardim maria lucia', N'Estudante', N'17981515290', N'atreus@hotmail.com', N'48143315096')
GO

ALTER TABLE [dbo].[Pessoas] ADD  DEFAULT (getdate()) FOR [DataInclusao]
GO
ALTER TABLE [dbo].[Pessoas] ADD  DEFAULT (CONVERT([bit],(1))) FOR [Ativado]
GO

