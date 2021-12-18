-- DELETE ALL TABLES

Use ER
GO

DECLARE @Sql NVARCHAR(500) DECLARE @Cursor CURSOR

SET @Cursor = CURSOR FAST_FORWARD FOR
SELECT DISTINCT sql = 'ALTER TABLE [' + tc2.TABLE_SCHEMA + '].[' +  tc2.TABLE_NAME + '] DROP [' + rc1.CONSTRAINT_NAME + '];'
FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc1
LEFT JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc2 ON tc2.CONSTRAINT_NAME =rc1.CONSTRAINT_NAME

OPEN @Cursor FETCH NEXT FROM @Cursor INTO @Sql

WHILE (@@FETCH_STATUS = 0)
BEGIN
Exec sp_executesql @Sql
FETCH NEXT FROM @Cursor INTO @Sql
END

CLOSE @Cursor DEALLOCATE @Cursor
GO

EXEC sp_MSforeachtable 'DROP TABLE ?'
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

CREATE TABLE Users (
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
	Date Date,
    PRIMARY KEY (Id),
    CONSTRAINT FK_WorkerId FOREIGN KEY (WorkerId) REFERENCES [ER].[dbo].[Worker](Id) );

GO


-------------------------------------------------------------------------------------
-- CREATE [InvoiceItems] TABLE

Use ER
GO

CREATE TABLE InvoiceItems(
    Id int NOT NULL UNIQUE,
    InvoiceId nvarchar(60) NOT NULL,
	ProductId nvarchar(60) NOT NULL,
	UnitValue Decimal(10,2),
	Cost Decimal(10,2),
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
	AND f.[Type] LIKE '%Garçom%'
	OR	f.[Type] LIKE '%garçom%'

GO


-------------------------------------------------------------------------------------
-- INSERT INTO [FUNCTION] TABLE

Use ER
GO

BEGIN
INSERT INTO [Function] ([Type]) VALUES 
('Garçom'),
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




--- Adicionando coluna CLientName na tabela Invoice

USE ER;

ALTER TABLE Invoice
ADD ClientName NVARCHAR(150);

GO

--- Adicionando coluna Quantity na tabela InvoiceItems

USE ER;

ALTER TABLE InvoiceItems
ADD Quantity INT DEFAULT 0 NOT NULL;

GO

--- Adicionando coluna Code na tabela Product

USE ER;

ALTER TABLE Product
ADD Code int;

GO

--- Adicionando ForeignKey UserId na tabela Invoice

USE ER;

ALTER TABLE [Invoice]
ADD UserId NVARCHAR(60),
FOREIGN KEY(UserId) REFERENCES [ER].[dbo].[Invoice](Id);

GO

--- Renomeando tabela [Users] para [User] 

USE ER;

exec sp_rename '[dbo].[Users]', '[dbo].[User]';

GO