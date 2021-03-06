-- DELETE DATABASE IF EXISTS AND RECREATE

USE tempdb;
GO

DECLARE @SQL nvarchar(1000);
IF EXISTS (SELECT 1 FROM sys.databases WHERE [name] = N'ER')
BEGIN
    SET @SQL = N'USE [ER];

                 ALTER DATABASE ER SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                 USE [tempdb];

                 DROP DATABASE ER;';
EXEC (@SQL);
END;

GO

USE master;
GO

CREATE DATABASE ER
GO


-- CREATE [Function] TABLE
Use ER
GO

CREATE TABLE [Function]
(
	Id int IDENTITY(1002,1) PRIMARY KEY,
	Type nvarchar(80)
);

GO

-------------------------------------------------------------------------------------
-- CREATE [Users] TABLE 

Use ER
GO

CREATE TABLE [User] (
    Id nvarchar(60) NOT NULL,
    UserName nvarchar(100) NOT NULL,
    Password nvarchar(255) NOT NULL,
    Role nvarchar(30) NOT NULL,
    PRIMARY KEY (Id)
);

GO

-------------------------------------------------------------------------------------
-- CREATE [Product] TABLE

Use ER
GO

CREATE TABLE Product(
    Id nvarchar(60) NOT NULL,
    Name nvarchar(100) NOT NULL,
	UnitValue Decimal(10,2),
	Cost Decimal(10,2),
	Code int,
    PRIMARY KEY (Id) );

GO

-------------------------------------------------------------------------------------
-- CREATE [Worker] TABLE

Use ER
GO

CREATE TABLE Worker(
    Id nvarchar(60) NOT NULL,
    FunctionId int NOT NULL,
	Name nvarchar(100) NOT NULL,
	Cpf nvarchar(20),
	PhoneNumber nvarchar(20),
	Address nvarchar(150),
	Email nvarchar(100),
    PRIMARY KEY (Id),
    CONSTRAINT FK_FunctionId FOREIGN KEY (FunctionId) REFERENCES [ER].[dbo].[Function](Id) );

GO

-------------------------------------------------------------------------------------
-- CREATE [Invoice] TABLE

Use ER
GO

CREATE TABLE Invoice(
    Id nvarchar(60) NOT NULL,
    WorkerId nvarchar(60) NOT NULL,
	UserId NVARCHAR(60),
	ClientName NVARCHAR(150),
	[Date] Date,
	Duration TIME,
    PRIMARY KEY (Id),
    CONSTRAINT FK_WorkerId FOREIGN KEY (WorkerId) REFERENCES [ER].[dbo].[Worker](Id),
	CONSTRAINT FK_UserId FOREIGN KEY(UserId) REFERENCES [ER].[dbo].[User](Id)
);

GO


-------------------------------------------------------------------------------------
-- CREATE [InvoiceItems] TABLE

Use ER
GO

CREATE TABLE InvoiceItem(
    Id nvarchar(60) NOT NULL UNIQUE,
    InvoiceId nvarchar(60) NOT NULL,
	ProductId nvarchar(60) NOT NULL,
	UnitValue Decimal(10,2),
	Cost Decimal(10,2),
	Quantity INT DEFAULT 0 NOT NULL,
    PRIMARY KEY (Id),
    CONSTRAINT FK_InvoiceId FOREIGN KEY (InvoiceId) REFERENCES [ER].[dbo].[Invoice](Id),
	CONSTRAINT FK_ProductId FOREIGN KEY (ProductId) REFERENCES [ER].[dbo].[Product](Id));

GO


-------------------------------------------------------------------------------------
-- CREATE [dbo.WorkersView] VIEW

Use ER
GO 
  
IF OBJECT_ID('dbo.WorkersView', 'V') IS NOT NULL
	 DROP VIEW dbo.WorkersView
GO
    
CREATE VIEW dbo.WorkersView AS

	SELECT W.[Id]
		 , W.[Name]
		 , W.[Cpf]
		 , W.[PhoneNumber]
		 , W.[Address]
		 , W.[Email]
		 , F.[Type]
	FROM [Worker] W inner join [Function] F
		 on F.Id = W.FunctionId;


GO

-------------------------------------------------------------------------------------
-- CREATE [dbo].[WaiterView]  VIEW

Use ER
GO 

DROP VIEW IF EXISTS [dbo].[WaiterView] 
GO

CREATE VIEW [WaiterView] 
AS

	SELECT W.[Id] as WorkerId
		 , W.[Name] 
	FROM 
		[Worker] w inner join [Function] f
		on w.[FunctionId] = f.[Id]
	where
		1=1
	AND f.[Type] LIKE '%Gar??om%'
	OR	f.[Type] LIKE '%gar??om%'

GO


-------------------------------------------------------------------------------------
-- INSERT INTO [FUNCTION] TABLE

Use ER
GO

BEGIN
INSERT INTO [Function] ([Type]) VALUES 
('Gar??om'),
('Caixa'),
('Gerente')
END

GO


-------------------------------------------------------------------------------------
-- INSERT INTO [Worker] TABLE 

USE [ER]
GO

INSERT INTO [dbo].[Worker]

	([Id],[FunctionId],[Name],[Cpf],[PhoneNumber],[Address],[Email])

 VALUES
    (NEWID(),1002,'Pedro','111111111111','21-958-585-551','Rua 1 Bairro 1, niteroi','pedro@gmail.com.br'),
	(NEWID(),1002,'joao','222222222222','21-958-585-552','Rua 2 Bairro 22 , niteroi','joao@gmail.com.br'),
	(NEWID(),1002,'Helena','333333333333','21-958-585-553','Rua 3 Bairro 3 , niteroi','Helena@gmail.com.br'),
	(NEWID(),1002,'Gustavo','444444444444','21-958-585-554','Rua 4 Bairro 4 , niteroi','Gustavo@gmail.com.br'),
	(NEWID(),1002,'Julia','555555555555','21-958-585-555','Rua 5 Bairro 5 , niteroi','Julia@gmail.com.br'),
	(NEWID(),1003,'Gloria','66666666666','21-958-585-556','Rua 6 Bairro 6 , niteroi','Gloria@gmail.com.br'),
	(NEWID(),1003,'Fabio','7777777777','21-958-585-557','Rua 7 Bairro 7 , niteroi','Fabio@gmail.com.br'),
	(NEWID(),1003,'Luiz','888888888888','21-958-585-558','Rua 8 Bairro 8 , niteroi','Luiz@gmail.com.br'),
	(NEWID(),1004,'Paula','999999999999','21-958-585-559','Rua 9 Bairro 9 , niteroi','Paula@gmail.com.br')

GO

-------------------------------------------------------------------------------------
-- INSERT INTO [Product] TABLE

USE [ER]
GO

INSERT INTO [dbo].[Product]

           ([Id],[Name],[UnitValue],[Cost])

     VALUES
           (NEWID(),'Coca-Cola',6.50,4.00),
		   (NEWID(),'Guarana',5.50,3.50),
		   (NEWID(),'Suco de Laranja',7.50,4.50),
		   (NEWID(),'Batata Frita',16.50,8.00),
		   (NEWID(),'Hamburguer',22.50,15.50),
		   (NEWID(),'Aneis de Cebola',28.50,19.00),
		   (NEWID(),'Picanha Fatiada',55.50,32.00),
		   (NEWID(),'Skol Lata',7.50,4.30),
		   (NEWID(),'Pizza Media',36.50,18.40),
		   (NEWID(),'Crepe Doce',25,16.70),
		   (NEWID(),'Crepe Salgado ',6.50,4.0)

GO


-------------------------------------------------------------------------------------
-- INSERT INTO [User] TABLE

INSERT INTO [User]
    ([Id],[UserName],[Password],[Role])
VALUES
    ('923B77C3-A8EE-481A-983D-66A74A8C3122','admin','$DNEFSA$V1$10000$HoX4J8+ZzVKcWv3+4tCyN6Eq3zGcuGG1HbOUv+tkpaktmuXg','admin')
GO

/****** Criando Tabela ActiveInvoice ******/

CREATE TABLE [dbo].[ActiveInvoice](
	[Id] [nvarchar](60) NOT NULL,
	[UserId] [nvarchar](60) NOT NULL,
	[WorkerId] [nvarchar](60) NOT NULL,
	[Date] [date] NULL,
	[ClientName] [nvarchar](150) NULL,
	[TableNumber] [smallint] NULL,
	[IndividualCheckNumber] [smallint] NULL,
	[StartTime] [time] NULL,
	PRIMARY KEY (Id),
    CONSTRAINT FK_UserId_ActiveInvoice FOREIGN KEY ([UserId]) REFERENCES [ER].[dbo].[User](Id),
	CONSTRAINT FK_WorkerId_ActiveInvoice FOREIGN KEY ([WorkerId]) REFERENCES [ER].[dbo].[Worker](Id)
);

GO


/****** Criando Tabela ActiveInvoiceItems ******/

CREATE TABLE [dbo].[ActiveInvoiceItem](
	[Id] [nvarchar](60) NOT NULL,
	[ActiveInvoiceId] [nvarchar](60) NOT NULL,
	[ProductId] [nvarchar](60) NOT NULL,
	[Quantity] [smallint] NOT NULL,
	PRIMARY KEY (Id) ,
	CONSTRAINT Fk_ActiveInvoiceId FOREIGN KEY ([ActiveInvoiceId]) REFERENCES [ER].[dbo].[ActiveInvoice]([Id]),
	CONSTRAINT Fk_ProductId_ActiveInvoiceIvems FOREIGN KEY ([ProductId]) REFERENCES [ER].[dbo].[Product]([Id])
)

GO


/****** Criando view [dbo].[InvoiceFlatModelView] . ******/


CREATE OR ALTER VIEW [dbo].[InvoiceFlatModelView]

AS
SELECT 
	[I].[Id] AS [Id],
	[I].[ClientName] AS [ClientName],
	[I].[Date] AS [Date],
	[I].[Duration] AS [Duration],
	[W].[Name] AS [WorkerName],
	(SELECT SUM([II].[UnitValue]*[II].[Quantity]) AS [Total] From [InvoiceItem] [II] Where  [II].[InvoiceId] = [I].[Id]) AS [TotalValue]
FROM
	[dbo].[Invoice] [I]
INNER JOIN
	[dbo].[Worker] [W]
ON
	[I].[WorkerId] = [W].[Id]

GO


/****** Criando tabela [dbo].[CheckManagementSetting] ******/

IF OBJECT_ID('[dbo].[CheckManagementSetting]', 'U') IS NOT NULL
DROP TABLE [dbo].[CheckManagementSetting]
GO

CREATE TABLE [dbo].[CheckManagementSetting]
(
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    UserId NVARCHAR(60) NOT NULL,
    TotalTables SMALLINT NOT NULL DEFAULT 50,
    TotalIndividualChecks SMALLINT NOT NULL DEFAULT 50,
    SideMenuAvailableTables BIT NOT NULL DEFAULT 1,
    SideMenuAvailableIndividualChecks BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_UserId_CheckManagementSettings
    FOREIGN KEY (UserId) 
    REFERENCES [dbo].[User](Id)
);
GO


/****** Criando configuracoes padrao usuario ******/

INSERT INTO [dbo].[CheckManagementSetting]
    ([Id],[UserId])
VALUES
    (NEWID(),'923B77C3-A8EE-481A-983D-66A74A8C3122')
GO

